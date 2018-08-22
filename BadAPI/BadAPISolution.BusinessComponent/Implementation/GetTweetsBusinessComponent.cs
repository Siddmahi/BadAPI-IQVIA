
using BadAPISolution.BusinessEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BadAPISolution.BusinessComponent
{
    public class GetTweetsBusinessComponent: IGetTweetsBusinessComponent
    {
        #region CONSTANTS
        private const int TweetPageSize = 100;
        public const string BaseAddress = "https://badapi.iqvia.io/";
        #endregion
        private readonly HttpClient _client = new HttpClient();

        public GetTweetsBusinessComponent(string baseAddress = BaseAddress) : this(new Uri(baseAddress))
        {
        }
        public GetTweetsBusinessComponent(Uri baseAddress)
        {
            _client.BaseAddress = baseAddress;
        }
        private async Task<List<Tweet>> GetTweetsAsync(DateTime startDate, DateTime endDate)
        {
            var url = $"/api/v1/Tweets?startDate={startDate:o}&endDate={endDate:o}";
            var jsonStream = await _client.GetStreamAsync(url);
            var serializer = new DataContractJsonSerializer(typeof(List<Tweet>));
            var tweets = (List<Tweet>)serializer.ReadObject(jsonStream);
            return tweets;
        }

        public List<Tweet> GetTweets(DateTime startDate, DateTime endDate)
        {
            List<Tweet> allTweets = GetAllTweetsAsync(startDate,endDate).Result;
            return allTweets;
        }

        public async Task<List<Tweet>> GetAllTweetsAsync(DateTime startDate, DateTime endDate)
        {
            var nextStartDate = startDate;
            List<Tweet> nextTweetsPage;
            var resultTweets = new List<Tweet>();
            do
            {
                nextTweetsPage = await GetTweetsAsync(nextStartDate, endDate);
                if (nextTweetsPage.Count > 0)
                {
                    resultTweets.AddRange(nextTweetsPage);
                    nextStartDate = nextTweetsPage[nextTweetsPage.Count - 1].DateTimeStamp.AddTicks(1);
                }
            }
            while (nextTweetsPage.Count >= TweetPageSize);
            return resultTweets;
        }

    }
}
