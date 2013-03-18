using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;
using System.Transactions;
using System.ComponentModel.Composition;


namespace VideoStore.Business.Components
{
    public class RecommendationProvider : IRecommendationProvider
    {
        public Recommendation GetRecommendationByMedia(Media pMedia) {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                Recommendation recommendation = lContainer.Recommendations.Where((pRecommendation) => pRecommendation.Medium.Id == pMedia.Id).FirstOrDefault();
                return recommendation;
            }
        }

        public Recommendation GetRecommendationById(int Id) {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                Recommendation recommendation = lContainer.Recommendations.Where((pRecommendation) => pRecommendation.Id == Id).FirstOrDefault();
                return recommendation;
            }
        }

        public void CreateRecommendation(Recommendation pRecommendation) {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Recommendations.AddObject(pRecommendation);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void UpdateRecommendation(Recommendation pRecommendation) {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Recommendations.Attach(pRecommendation);
                lContainer.ObjectStateManager.ChangeObjectState(pRecommendation, System.Data.EntityState.Modified);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void DeleteRecommendation(Recommendation pRecommendation) {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Recommendations.DeleteObject(pRecommendation);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        //TODO; not sure if it works
        public void UserLikeAnMedia(int pUserId, int pMediaId) {

            if (pUserId == null || pMediaId == null) {
                return;
            }

            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.ContextOptions.LazyLoadingEnabled = false;
                var pUser = lContainer.Users.Include("Medium").FirstOrDefault(lUser => lUser.Id == pUserId);
                var pMedia = lContainer.Media.Include("Recommendation").Where(lMedia => lMedia.Id == pMediaId).FirstOrDefault();

                if (pUser == null || pMedia == null) {
                    return;
                }

                //get the List of the medias which are liked by this user
                List<Media> LikedMedium  = pUser.Medium.ToList();
                foreach( Media tMedia in LikedMedium ){
                    if (tMedia.Id == pMedia.Id) {
                        return;
                    }
                }

                // when no one has liked this Media before, create a recommendation model attached to this media
                if (pMedia.Recommendation == null)
                {
                    Recommendation newRec = new Recommendation();
                    newRec.Medium = pMedia;
                    newRec.MostLikeMatching = null;
                    lContainer.Recommendations.AddObject(newRec);
                    lContainer.SaveChanges();
                }
                
                var pRecommendation = new Recommendation();
                var curRecommendation = pMedia.Recommendation;// the recommendation of the new liked Media
                List<LikeMatching> pLikeMatchings  = new List<LikeMatching>();


                //iterate the media list & update all the LikeMatchings
                foreach (Media tMedia in LikedMedium)
                {
                    // update LikeWatching list attached to every of the Recommendation of this media
                    pRecommendation = lContainer.Recommendations.Include("LikeMatchings")
                        .Where( (lRecommendation) => lRecommendation.Medium.Id == tMedia.Id ).FirstOrDefault();

                    //pLikeMatchings = pRecommendation.LikeMatchings.ToList();
                    pLikeMatchings = lContainer.LikeMatchings.Include("Medium").Where(lLikeMatching => lLikeMatching.Recommendation.Id == pRecommendation.Id).ToList();
                    LikeMatching MatchingToUpdate = GetLikeMatchingMediaIn(pMedia,pLikeMatchings);
                    if( MatchingToUpdate != null ){
                        // if this media is in the previous LikeMatching list of 
                        //this recommendation, increment the count by 1
                        MatchingToUpdate.count++;
                        lContainer.LikeMatchings.Attach(MatchingToUpdate);
                        lContainer.ObjectStateManager.ChangeObjectState(MatchingToUpdate, System.Data.EntityState.Modified);
                    }
                    else{//add this media to the LikeMatching List of this Recommendation and set the count as 1
                        MatchingToUpdate = new LikeMatching();
                        MatchingToUpdate.Recommendation = pRecommendation;
                        MatchingToUpdate.Medium = pMedia;
                        MatchingToUpdate.count = 1;
                        lContainer.LikeMatchings.AddObject(MatchingToUpdate);
                        lContainer.SaveChanges();    
                    }
                                
                    // recalculate the most frequently liked media of this Recomendtaion
                    pRecommendation.MostLikeMatching = (from LikingItem in pRecommendation.LikeMatchings
                                                            orderby LikingItem.count descending
                                                            select LikingItem).FirstOrDefault();
                    lContainer.Recommendations.Attach(pRecommendation);
                    lContainer.ObjectStateManager.ChangeObjectState(pRecommendation, System.Data.EntityState.Modified);
                    //lContainer.SaveChanges();

                    //update the LikeMatching list for the new liked media
                    List<LikeMatching> tLikeMatchings = lContainer.LikeMatchings.Include("Medium").Where(lLikeMatching => lLikeMatching.Recommendation.Id == curRecommendation.Id).ToList();
                    MatchingToUpdate = (from LikeItem in tLikeMatchings
                                        where LikeItem.Medium.Id == tMedia.Id
                                        select LikeItem).FirstOrDefault();
                    if (MatchingToUpdate != null)
                    {
                        // if this media is in the previous LikeMatching list of 
                        // this recommendation, increment the count by 1
                        MatchingToUpdate.count++;
                        lContainer.LikeMatchings.Attach(MatchingToUpdate);
                        lContainer.ObjectStateManager.ChangeObjectState(MatchingToUpdate, System.Data.EntityState.Modified);
                    }
                    else {
                        // add this media to the LikeMatching List of this Recommendation and set the count as 1
                        MatchingToUpdate = new LikeMatching();
                        MatchingToUpdate.Recommendation = curRecommendation;
                        MatchingToUpdate.Medium = tMedia;
                        MatchingToUpdate.count = 1;
                        lContainer.LikeMatchings.AddObject(MatchingToUpdate);
                        lContainer.SaveChanges();    
                    }

                }

                // recalculate the most frequently liked media of this Recomendtaion
                curRecommendation.MostLikeMatching = (from LikingItem in curRecommendation.LikeMatchings
                                                    orderby LikingItem.count descending
                                                    select LikingItem).FirstOrDefault();
                lContainer.Recommendations.Attach(curRecommendation);
                lContainer.ObjectStateManager.ChangeObjectState(curRecommendation, System.Data.EntityState.Modified);

                //put the media in this user's Media-like list
                pUser.Medium.Add(pMedia);
                lContainer.Users.Attach(pUser);
                lContainer.ObjectStateManager.ChangeObjectState(pUser, System.Data.EntityState.Modified);

                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        //TODO: not sure if it works
        public List<Media> GetRecommendationListByUserId(int UserId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.ContextOptions.LazyLoadingEnabled = false;
                List<Media> Result = new List<Media>();
                var pUser = lContainer.Users.Include("Medium").FirstOrDefault(lUser => lUser.Id == UserId );
                //get the media list of this user
                List<Media> pMediaOfUser = pUser.Medium.ToList();
                                
                foreach(Media pMedia in pMediaOfUser){
                    Recommendation pRecommendation = lContainer.Recommendations.Include("MostLikeMatching").FirstOrDefault(lRecommendation => lRecommendation.Medium.Id == pMedia.Id);
                    //for every media, find the binded recommendation and find the most frequent LikeMatching binded to it
                    LikeMatching tLikeMatching = pRecommendation.MostLikeMatching;
                    tLikeMatching = lContainer.LikeMatchings.Include("Medium").FirstOrDefault( lLikeMatching => lLikeMatching.Id == tLikeMatching.Id );
                    //add the media binded with this LikeMatching to the Media List
                    if (tLikeMatching != null && tLikeMatching.Medium != null) {
                        Result.Add(tLikeMatching.Medium);
                    }
                    tLikeMatching = null;
                }

                return this.RipResultList(Result, pMediaOfUser);
            }
            
        }

        private LikeMatching GetLikeMatchingMediaIn(Media pMedia, List<LikeMatching> LikeMatchingList)
        {
            foreach (LikeMatching pLikeMatching in LikeMatchingList)
            {
                if (pLikeMatching.Medium.Id == pMedia.Id)
                {
                    return pLikeMatching;
                }
            }
            return null;
        }

        private List<Media> RipResultList(List<Media> OriginalList, List<Media> pMediaOfUser) {
            List<Media> tList = new List<Media>();
            //remove the duplicated ones
            OriginalList.Sort(
                delegate(Media a, Media b)
                {
                    int xdiff = a.Id.CompareTo(b.Id);
                    if (xdiff != 0) { return xdiff; }
                    else { return a.Id.CompareTo(b.Id); }
                }
            );
            int ResultCount = OriginalList.Count;

            if (ResultCount != 0)
            {
                tList.Add(OriginalList[0]);
            }
            for (int i = 1; i < ResultCount; i++)
            {
                if (OriginalList[i - 1].Id != OriginalList[i].Id)
                {
                    tList.Add(OriginalList[i]);
                }
            }
            OriginalList = tList;
            tList = new List<Media>();
            var tIdList = new List<int>();//store the media Id duplicates the media in user's like_list

            //remove the recommended media that the user has already liked
            int pMediaOfUserCount = pMediaOfUser.Count;
            for (int i = 0; i < pMediaOfUserCount; i++)
            {
                for (int j = 0; j < OriginalList.Count; j++)
                {
                    if (pMediaOfUser[i].Id == OriginalList[j].Id)
                    {
                        tIdList.Add(OriginalList[j].Id);
                    }
                }
            }

            bool dupFlag = false;
            foreach (Media m in OriginalList)
            {
                foreach (int id in tIdList)
                {
                    if (id == m.Id)
                    {
                        dupFlag = true;
                    }
                }
                if (!dupFlag)
                {
                    tList.Add(m);
                }
                dupFlag = false;
            }

            OriginalList = tList;

            return OriginalList;
        }

    }
}
