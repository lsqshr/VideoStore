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
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                var pUser = lContainer.Users.Include("Medium").FirstOrDefault(lUser => lUser.Id == pUserId);
                var pMedia = lContainer.Media.Include("Recommendation").Where(lMedia => lMedia.Id == pMediaId).FirstOrDefault();
                //get the List of the medias which are liked by this user
                List<Media> LikedMedium  = pUser.Medium.ToList();
                var pRecommendation = new Recommendation();
                List<LikeMatching> pLikeMatchings  = new List<LikeMatching>();
                
                //iterate the media list & update all the LikeMatchings
                foreach (Media tMedia in LikedMedium)
                {
                    // update LikeWatching list attached to every of the Recommendation of this media
                    pRecommendation = lContainer.Recommendations.Include("LikeMatchings")
                        .Where( (lRecommendation) => lRecommendation.Medium.Id == tMedia.Id ).FirstOrDefault();
                    pLikeMatchings = pRecommendation.LikeMatchings.ToList();
                    LikeMatching MatchingToUpdate = GetLikeMatchingMediaIn(pMedia,pLikeMatchings);
                    if( MatchingToUpdate != null ){
                        // if this media is in the previous LikeMatching list of 
                        //this recommendation, increment the count by 1
                        MatchingToUpdate.count++;
                    }
                    else{//add this media to the LikeMatching List of this Recommendation and set the count as 1
                        MatchingToUpdate = new LikeMatching();
                        MatchingToUpdate.Recommendation = pRecommendation;
                        MatchingToUpdate.Medium = pMedia;
                        MatchingToUpdate.count = 1;
                    }
                    lContainer.LikeMatchings.Attach(MatchingToUpdate);
                    lContainer.ObjectStateManager.ChangeObjectState(MatchingToUpdate, System.Data.EntityState.Modified);
                    //lContainer.SaveChanges();                
                    // recalculate the most frequently liked media of this Recomendtaion
                    pRecommendation.MostLikeMatching = (from LikingItem in lContainer.LikeMatchings
                                                            orderby LikingItem.count descending
                                                            select LikingItem).FirstOrDefault();
                    lContainer.Recommendations.Attach(pRecommendation);
                    lContainer.ObjectStateManager.ChangeObjectState(MatchingToUpdate,System.Data.EntityState.Modified);
                    //lContainer.SaveChanges();
                }
                
                // when no one has liked this Media before, create a recommendation model attached to this media
                if (pMedia.Recommendation == null) {
                    Recommendation newRec = new Recommendation();
                    newRec.Medium = pMedia;
                    newRec.MostLikeMatching = null;
                    lContainer.Recommendations.AddObject(newRec);
                }
                
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
                List<Media> Result = new List<Media>();
                var pUser = lContainer.Users.Include("Medium").FirstOrDefault(lUser => lUser.Id == UserId );
                //get the media list of this user
                List<Media> pMediaOfUser = pUser.Medium.ToList();
                LikeMatching tLikeMatching = null;
                
                foreach(Media pMedia in pMediaOfUser){
                    //for every media, find the binded recommendation and find the most frequent LikeMatching binded to it
                    tLikeMatching = pMedia.Recommendation.MostLikeMatching;
                    //add the media binded with this LikeMatching to the Media List
                    if (tLikeMatching != null && tLikeMatching.Medium != null) {
                        Result.Add(tLikeMatching.Medium);
                    }
                    tLikeMatching = null;
                }

                return Result;
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

    }
}
