using InjectApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace InjectApp.Controllers
{
    public class InjectController : Controller
    {
        private const string CASHEDINJECTKEY = "CACHEDINJECTKEY";

        [HttpGet]
        public ActionResult Inject()
        {
            var editInjectModel = new EditInjectModel();
            editInjectModel.EditModel = new InjectModel();
            editInjectModel.InjectModel = CurrentInjectModel;
            return View(editInjectModel);
        }

        [HttpPost]
        public ActionResult Inject(InjectModel injectModel)
        {
            CurrentInjectModel = injectModel;
            return RedirectToAction("Inject");
        }

        private InjectModel CurrentInjectModel
        {
            get
            {
                if (HttpContext.Cache[CASHEDINJECTKEY] == null)
                {
                    var injectModel = new InjectModel();
                    HttpContext.Cache.Insert(CASHEDINJECTKEY, injectModel, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20));
                }
                return (InjectModel)HttpContext.Cache[CASHEDINJECTKEY];
            }
            set
            {
                HttpContext.Cache.Insert(CASHEDINJECTKEY, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20));
            }
        }

        [HttpGet]
        public ActionResult InView()
        {
            if (CurrentInjectModel == null)
            {
                return Redirect("http://google.com");
            }
            return View(CurrentInjectModel);
        }
    }
}
