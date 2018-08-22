using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BadAPISolution.BusinessEntities
{ 
    public class Tweet
    {
        public string Id { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string Text { get; set; }
    }
}