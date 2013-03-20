using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Services.Interfaces;
using VideoStore.Business.Entities;
using VideoStore.Business.Components.Interfaces;

namespace VideoStore.Services
{
    class RecommendationService : IRecommendationService
    {
        private IRecommendationProvider RecommendationProvider
        {
            get
            {
                return ServiceFactory.GetService<IRecommendationProvider>();
            }
        }

        public void UserLikeMedia(int pUserId, int pMediaId)
        {
            this.RecommendationProvider.UserLikeAnMedia(pUserId, pMediaId);
        }

        public List<Recommendation> GetRecommendationListByUserId(int UserId)
        {
            return this.RecommendationProvider.GetRecommendationListByUserId(UserId);
        }
    }
}
