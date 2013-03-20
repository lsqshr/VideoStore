using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VideoStore.Business.Entities;

namespace VideoStore.Services.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRecommendationService
    {
        [OperationContract]
        void UserLikeMedia(int pUserId, int pMediaId);

        [OperationContract]
        List<Recommendation> GetRecommendationListByUserId(int UserId);
    }
}
