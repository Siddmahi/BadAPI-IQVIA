using BadAPISolution.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadAPISolution.BusinessComponent
{
   public interface IGetTweetsBusinessComponent
    {
        List<Tweet> GetTweets(DateTime startDate, DateTime endDate);
    }
}
