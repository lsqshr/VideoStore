using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components.Interfaces
{
    public interface IRecommendationProvider
    {
        Recommendation GetRecommendationByMedia(Media pMedia);
        Recommendation GetRecommendationById(int Id);
        void CreateRecommendation(Recommendation pRecommendation);
        void UpdateRecommendation(Recommendation pRecommendation);
        void DeleteRecommendation(Recommendation pRecommendation);
        void UserLikeAnMedia( int pUserId, int pMediaId );
        List<Recommendation> GetRecommendationListByUserId(int UserId);
    }
}
