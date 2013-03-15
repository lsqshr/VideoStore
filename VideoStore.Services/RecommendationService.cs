using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Components;
using VideoStore.Business.Entities;
using VideoStore.Business.Components.Interfaces;

namespace VideoStore.Services
{
    class RecommendationService
    {

        private IRecommendationProvider RecommendationProvider
        {
            get
            {
                return ServiceFactory.GetService<IRecommendationProvider>();
            }
        }

        public void UserLikeMedia(int pUserId, int pMediaId) {
            this.RecommendationProvider.UserLikeAnMedia(pUserId, pMediaId);
        }

        List<Media> GetRecommendationListByUserId(int UserId) {
            return null;
        }
    }
}
