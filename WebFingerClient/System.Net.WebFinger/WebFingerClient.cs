using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;


namespace System.Net.WebFinger
{
    /// <summary>
    /// Inspired by the work
    /// https://github.com/jcarbaugh/python-webfinger/blob/master/webfinger.py
    /// </summary>
    public class WebFingerClient
    {

        private HttpClient __httpClient;
        private HttpRequestMessage __httpRequestMessage;
        private HttpResponseMessage __httpResponseMessage;
        private HttpContent __httpContent;


        //private int __timeout;
        private bool __official;
        private string __host;
        public string Host
        {
            get
            {
                return this.__host;
            }
        }

        private string __resource;
        public string Resource 
        {
            get 
            {
                return this.__resource;
            }
            set
            {
                this.__resource = value;

                this.ParseResource(this.__resource);
            }
        }


        public WebFingerClient(bool Official = false)
        {
            this.__official = Official;
        }

       /// <summary>
       /// parses resources and set __host variable
       /// </summary>
       /// <param name="resource"></param>
       /// <returns></returns>
        private string ParseResource(string resource)
        {
            this.__host = resource.Substring(resource.LastIndexOf('@')+1);

            if ((this.__official == false) && (Globals.UNOFFICIAL_ENDPOINTS.ContainsKey(this.__host)))
            {
                this.__host = Globals.UNOFFICIAL_ENDPOINTS[this.__host];       
            }
            return this.__host;
        }


        public WebFingerResponseMessage Finger(string resource)
        {
            this.Resource = resource;
            return Finger();
        }

        public WebFingerResponseMessage Finger()
        {
            var uriBuilder = new UriBuilder(string.Format("https://{0}/.well-known/webfinger", this.__host));
            var queryStrings = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryStrings.Add("resource", this.__resource);
            uriBuilder.Query = queryStrings.ToString();

            //var url = string.Format("https://{0}/.well-known/webfinger",this.__host);
            this.__httpClient = new HttpClient();

            //this.__httpRequestMessage  = new HttpRequestMessage(HttpMethod.Get,url);
            this.__httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            this.__httpRequestMessage.Headers.Add("User-Agent", string.Format("csharp-webfinger{0}", Globals.VERSION));
            this.__httpRequestMessage.Headers.Add("Accept", Globals.WEBFINGER_TYPE);

            this.__httpResponseMessage = this.__httpClient.SendAsync(this.__httpRequestMessage).Result;    //we prefer blocking calls only

            this.__httpContent = this.__httpResponseMessage.Content;

            //get content type header
            string content_type = string.Empty;
            content_type = this.__httpContent.Headers.ContentType.MediaType;

            if ((content_type != Globals.WEBFINGER_TYPE) && (Globals.LEGACY_WEBFINGER_TYPES.Contains(content_type) == false))
            {
                throw new WebFingerException("Invalid response type from server");
            }

            string result = this.__httpResponseMessage.Content.ReadAsStringAsync().Result;
            return new WebFingerResponseMessage(result) { ContentType = content_type };  //we prefer blocking calls only
        }

    }
}
