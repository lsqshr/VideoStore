using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Business.Entities;


namespace VideoStore.WebClient.ViewModels
{
    public class RecommendationViewModel
    {
        public RecommendationViewModel(string pUserName)
        {
            User pUser = this.UserService.ReadUserByName(pUserName);
            this.pUserId = pUser.Id;

        }

        public Recommendation[] RecommendationListPage
        {
            get
            {
                Recommendation[] r = RecommendationService.GetRecommendationListByUserId(pUserId);
                if (r.Length == 0) {
                    return new Recommendation[0];
                }
                return r;
            }
        }

        public void LikeMedia(int MediaId)
        {
            this.RecommendationService.UserLikeMedia(this.pUserId, MediaId);
        }

        private RecommendationService.RecommendationServiceClient RecommendationService {
            get 
            {
                return new RecommendationService.RecommendationServiceClient();
            }
        }

        private UserService.UserServiceClient UserService {
            get 
            { 
                return new UserService.UserServiceClient();
            }
        }

        public int pUserId { get; set; }
    }
}