using BadAPISolution.BusinessComponent;
using BadAPISolution.BusinessEntities;
using BadAPISolution.UI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadAPISolution.UI.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public ActionResult GetTweets()
        {
            TweetViewModel vm = new TweetViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult GetTweets(TweetViewModel tRequest)
        {
            var StartDate = tRequest.TweetRequest.StartDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            var EndDate = tRequest.TweetRequest.EndDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            DateTime TestStartDate = DateTime.Parse(StartDate, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            DateTime TestEndDate = DateTime.Parse(EndDate, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
            TweetViewModel vm = new TweetViewModel();
            vm.Tweet = BusinessComponentFactory.GetTweetsBusinessComponent.GetTweets(TestStartDate, TestEndDate);
            return View(vm);
        }
    }

}
