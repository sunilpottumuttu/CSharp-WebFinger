using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.WebFinger
{
    internal class Globals
    {
        public static readonly string VERSION = "1.0";
        public static readonly Dictionary<string, string> RELS = new Dictionary<string, string>() 
        { 
            {"activity_streams", "http://activitystrea.ms/spec/1.0"},
            {"avatar", "http://webfinger.net/rel/avatar"},
            {"hcard", "http://microformats.org/profile/hcard"},
            {"open_id", "http://specs.openid.net/auth/2.0/provider"},
            {"opensocial", "http://ns.opensocial.org/2008/opensocial/activitystreams"},
            {"portable_contacts", "http://portablecontacts.net/spec/1.0"},
            {"profile", "http://webfinger.net/rel/profile-page"},
            {"webfist", "http://webfist.org/spec/rel"},
            {"xfn", "http://gmpg.org/xfn/11"}
        };

        public static readonly string WEBFINGER_TYPE = @"application/jrd+json";
        public static readonly List<string> LEGACY_WEBFINGER_TYPES = new List<string> { @"application/json" };

        public static readonly Dictionary<string, string> UNOFFICIAL_ENDPOINTS = new Dictionary<string, string>()
        {
           {"facebook.com", "facebook-webfinger.appspot.com"},
           {"twitter.com", "twitter-webfinger.appspot.com"}
        };
    }
}
