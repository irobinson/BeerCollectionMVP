using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Antlr3.ST;
using DotNetNuke.ComponentModel;
using DotNetNuke.Entities.Profile;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Profile;
using MbUnit.Framework;
using Moq;
using Assert = MbUnit.Framework.Assert;

namespace BeerCollectionMVP.Tests
{
    [TestFixture]
    public class StringTemplateTests
    {
        [Test]
        public void TestMethod1()
        {
            IDictionary<string, object> ret = new Dictionary<string, object>();
            ret["elem1"] = true;
            ret["elem2"] = false;

            var nestedObj = new Dictionary<string, object>();
            nestedObj["nestedProp"] = 100;
            ret["elem3"] = nestedObj;

            var template = new StringTemplate("$elem1$ or $elem2$ and value: $elem3.nestedProp$") {Attributes = ret};

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            template.Write(new NoIndentWriter(writer));
            writer.Flush();

            var renderedText = sb.ToString();

            Assert.AreEqual(renderedText, "True or False and value: 100");
        }

        [Test]
        public void TestMethod2()
        {
            var template = new StringTemplate("$user:{ u | $u.FirstName$ is a super user? $u.IsSuperUser$. But his last name is $u.LastName$.}$");
            template.SetAttribute("user", new
                                              {
                                                  FirstName = "Ian",
                                                  LastName = "Robinson",
                                                  IsSuperUser = false
                                              });

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            template.Write(new NoIndentWriter(writer));
            writer.Flush();

            var renderedText = sb.ToString();

            Assert.AreEqual(renderedText, "Ian is a super user? False. But his last name is Robinson.");
        }
    }
}