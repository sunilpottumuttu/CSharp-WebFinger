using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.WebFinger
{
    public class WebFingerException:Exception
    {
        public WebFingerException(string message):base(message)
        {

        }
    }
}
