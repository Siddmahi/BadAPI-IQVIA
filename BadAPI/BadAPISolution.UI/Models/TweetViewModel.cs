using BadAPISolution.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BadAPISolution.UI.Models
{
    public class TweetViewModel
    {
        public List<Tweet> Tweet { get; set; }
        public TweetRequestDTO TweetRequest { get; set; }
    }
}