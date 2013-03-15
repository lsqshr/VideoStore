using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using VideoStore.Business.Entities;

namespace VideoStore.Services.Interfaces
{
    [ServiceContract]
    public interface IRecommendationService
    {
        [OperationContract]
        void UserLikeMedia(int pUserId, int pMediaId);

        [OperationContract]
        List<Media> GetRecommendationListByUserId(int UserId);

    }
}
