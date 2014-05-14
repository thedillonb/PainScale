using System;
using PainScale.iOS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortableRest;
using System.Net.Http;

namespace PainScale.iOS.Services
{
    public class ApplicationService
    {
        public static readonly Lazy<ApplicationService> _instance = new Lazy<ApplicationService>(() => new ApplicationService());

        public static ApplicationService Instance
        {
            get { return _instance.Value; }
        }

        public RestClient RestClient { get; private set; }

        private ApplicationService()
        {
            RestClient = new RestClient();
            RestClient.BaseUrl = "http://pain-scale.herokuapp.com";
        }

        public async Task<List<HistoryModel>> RetrieveHistory()
        {
            var request = new RestRequest("/levels", HttpMethod.Get);
            return await RestClient.ExecuteAsync<List<HistoryModel>>(request).ConfigureAwait(false);
  
        }

        public async Task<List<ReasonModel>> RetrieveReasons()
        {
            var request = new RestRequest("/reasons", HttpMethod.Get);
            return await RestClient.ExecuteAsync<List<ReasonModel>>(request).ConfigureAwait(false);
        }
    }
}

