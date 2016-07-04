
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SubscriberPlugin
{
    [TestFixture]
    public class UnitTest
    {
        public SubPlugin Plugin { get; set; }
        [SetUp]
        public void SetUp()
        {
            Plugin = new SubPlugin();
        }
        [Test]
        public void Test()
        {
            
        }
    }
}
