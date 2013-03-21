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
    public class CatalogueProvider : ICatalogueProvider
    {
        public List<Entities.Media> GetMediaItems(int pOffset, int pCount)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return (from MediaItem in lContainer.Media
                       orderby MediaItem.Id
                       select MediaItem).Skip(pOffset).Take(pCount).ToList();
            }
        }


        public Media GetMediaById(int pId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return (from MediaItem in lContainer.Media
                        where MediaItem.Id == pId
                        select MediaItem).FirstOrDefault();
            }
        }

        public List<Media> GetMediumUserLikes(int pUserId)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                User pUser = lContainer.Users.Include("Medium").Where((tUser) => tUser.Id == pUserId).FirstOrDefault();
                lScope.Complete();
                return pUser.Medium.ToList();

            }
        }

        public bool IsMediaLikedByUser(Media pMedia, User pUser) { 
            //get the medias this user liked before
            List<Media> mList = this.GetMediumUserLikes(pUser.Id);
            bool b =  false;
            foreach(Media m in mList){
                if (m.Id == pMedia.Id) {
                    b = true;
                }
            }
            return b;
        }

    }
}
