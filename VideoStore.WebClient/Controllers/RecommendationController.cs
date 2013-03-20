using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Business.Entities;
using VideoStore.WebClient.ViewModels;

namespace VideoStore.WebClient.Controllers
{
    public class RecommendationController : Controller
    {
        //
        // GET: /Recommendation/
        public ActionResult Index()
        {
            return View(new RecommendationViewModel(this.User.Identity.Name));
        }

    }
}
