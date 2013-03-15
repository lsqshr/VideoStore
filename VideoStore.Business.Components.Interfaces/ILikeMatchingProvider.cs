using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components.Interfaces
{
    public interface ILikeMatchingProvider
    {
        LikeMatching GetLikeMatchingById(int Id);
        void CreateLikeMatching(LikeMatching pLikeMatching);
        void UpdateLikeMatching(LikeMatching pLikeMatching);
        void DeleteLikeMatching(LikeMatching pLikeMatching);
    }
}
