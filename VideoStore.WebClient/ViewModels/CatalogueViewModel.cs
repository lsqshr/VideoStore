using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Business.Entities;

namespace VideoStore.WebClient.ViewModels
{
    public class CatalogueViewModel
    {

        private CatalogueService.CatalogueServiceClient CatalogueService
        {
            get
            {
                return new CatalogueService.CatalogueServiceClient();
            }
        }

        private UserService.UserServiceClient UserService
        {
            get
            {
                return new UserService.UserServiceClient();
            }
        }

        private bool IsMediaLikedByUser(Media pMedia) {
            return this.CatalogueService.IsMediaLikedByUser(pMedia,CurrentUser);
        }

        private string UserName;

        public CatalogueViewModel(string username)
        {
            this.UserName = username;
        }

        public class MediaWithLikeStatus 
        {
            public Media pMedia { get; set; }
            public bool Liked{get;set;}
            public MediaWithLikeStatus(Media pMedia,bool liked) {
                this.Liked = liked;
                this.pMedia = pMedia;
            }
        }

        public List<MediaWithLikeStatus> MediaListPage
        {
            get
            {
                List<MediaWithLikeStatus> mwsList= new List<MediaWithLikeStatus>();
                List<Media> mList = CatalogueService.GetMediaItems(0, Int32.MaxValue);
                foreach(Media m in mList)
                {
                    if (IsMediaLikedByUser(m))
                    {
                        mwsList.Add(new MediaWithLikeStatus(m, true));
                    }
                    else {
                        mwsList.Add(new MediaWithLikeStatus(m, false));
                    }
                }
                return mwsList;
            }
        }

        public User CurrentUser {
            get {
                return UserService.ReadUserByName(this.UserName);
            }
        }

    }
}