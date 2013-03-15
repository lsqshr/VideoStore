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
    class LikeMatchingProvider : ILikeMatchingProvider
    {

        public LikeMatching GetLikeMatchingById(int Id)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                LikeMatching pLikeMatching = lContainer.LikeMatchings.Where((tLikeMatching) => tLikeMatching.Id == Id).FirstOrDefault();
                return pLikeMatching;
            }
        }

        public void CreateLikeMatching(LikeMatching pLikeMatching) 
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.LikeMatchings.AddObject(pLikeMatching);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void UpdateLikeMatching(LikeMatching pLikeMatching)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.LikeMatchings.Attach(pLikeMatching);
                lContainer.ObjectStateManager.ChangeObjectState(pLikeMatching, System.Data.EntityState.Modified);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void DeleteLikeMatching(LikeMatching pLikeMatching)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.LikeMatchings.DeleteObject(pLikeMatching);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public List<LikeMatching> GetLikeMatchingsByRecommendation(Recommendation pRecommendation)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return pRecommendation.LikeMatchings.ToList();
            }
        }

        public LikeMatching GetMostFrequentLikeMatchingByRecommendation(Recommendation pRecommendation)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return pRecommendation.MostLikeMatching;
            }
        }

    }
}
