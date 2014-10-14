using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.WebFinger;

namespace WebFinger.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParsing()
        {
            WebFingerClient wfc = new WebFingerClient();
            wfc.Resource ="eric@konklone.com";
            Assert.AreEqual(wfc.Host, "konklone.com");
        }


        [TestMethod]
        public void TestOfficialParsing()
        {

            WebFingerClient wfc = new WebFingerClient(Official: true);
            wfc.Resource = "konklone@twitter.com";
            Assert.AreEqual(wfc.Host, "twitter.com");
        }


        [TestMethod]
        public void TestUnOfficialParsing()
        {

            WebFingerClient wfc = new WebFingerClient(Official: false);
            wfc.Resource ="konklone@twitter.com";
            Assert.AreEqual(wfc.Host, "twitter-webfinger.appspot.com");
        }


        [TestMethod]
        public void TestSubject()
        {
            WebFingerClient wfc = new WebFingerClient();
            wfc.Resource = "acct:eric@konklone.com";
            WebFingerResponseMessage wfrm =  wfc.Finger();
            var subject = wfrm.Jrd.subject;
            Assert.AreEqual(subject, "acct:eric@konklone.com");
        }
    }
}
