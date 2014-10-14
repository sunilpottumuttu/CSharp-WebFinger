using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebFinger;

namespace WebFingerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("Please Enter A Resource(Ex:acct:eric@konklone.com)");
                var resource = Console.ReadLine();

                WebFingerClient wfc = new WebFingerClient(Official: true);
                WebFingerResponseMessage wfrm = wfc.Finger(resource);
                Console.WriteLine(wfrm.ToString());
                Console.WriteLine(Environment.NewLine);

            }
        }
    }
}
