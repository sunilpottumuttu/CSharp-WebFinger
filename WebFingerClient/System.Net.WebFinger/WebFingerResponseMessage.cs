using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace System.Net.WebFinger
{

    public class JRD
    {
        public string subject { get; set; }
        public Properties properties { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Properties
    {
        public string type{ get; set; }
    }


    #region COMMENTED SAMPLE JRD REQUEST
    //{
    //  "subject": "acct:eric@konklone.com",
    //  "properties": {
    //    "http://schema.org/name": "Eric Mill"
    //  },
    //  "links": [
    //    {
    //      "rel": "http://webfinger.net/rel/profile-page",
    //      "href": "https://konklone.com"
    //    },
    //    {
    //      "rel": "http://webfinger.net/rel/avatar",
    //      "href": "https://secure.gravatar.com/avatar/ac3399caecce27cb19d381f61124539e.jpg?s=400"
    //    }
    //  ]
    //} 
    #endregion

    /// <summary>
    /// Response that wraps an RD object. 
    /// It provides attribute-style access  to links for specific rels, responding with the href attribute  of the matched element.
    /// </summary>
    public class WebFingerResponseMessage
    {

        public string  ContentType { get; set; }

        public JRD Jrd { get; set; }

        private string __jsonResourceDescriptor;
        public new string ToString()
        {
            return this.__jsonResourceDescriptor;
        }
        
        internal WebFingerResponseMessage(string jsonResourceDescriptor)
        {
            try
            {
                this.__jsonResourceDescriptor = jsonResourceDescriptor;
                this.Jrd = JsonConvert.DeserializeObject<JRD>(jsonResourceDescriptor);
            }
            catch (Exception ex)
            {
                throw new WebFingerException(ex.Message);
            }
        }

    }
}
