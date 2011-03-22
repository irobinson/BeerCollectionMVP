using System.Collections.Generic;
using System.Linq;
using Antlr3.ST;
using MbUnit.Framework;

namespace BeerCollectionMVP.Tests.Examples
{
    [TestFixture]
    public class StringTemplateUsageExamples
    {
        [Test]
        public void NestedProperties()
        {
            // Arrange
            IDictionary<string, object> ret = new Dictionary<string, object>();
            ret["elem1"] = true;
            ret["elem2"] = false;

            var nestedObj = new Dictionary<string, object>();
            nestedObj["nestedProp"] = 100;
            ret["elem3"] = nestedObj;

            var template = new StringTemplate("$elem1$ or $elem2$ and value: $elem3.nestedProp$") { Attributes = ret };

            // Act
            var renderedText = template.ToString();

            // Assert
            Assert.AreEqual(renderedText, "True or False and value: 100");
        }

        [Test]
        public void ListIterator_SingleItem()
        {
            // Arrange
            var template = new StringTemplate("$user:{ u | $u.FirstName$ is a super user? $u.IsSuperUser$. But his last name is $u.LastName$.}$");
            template.SetAttribute("user", new
                                              {
                                                  FirstName = "Ian",
                                                  LastName = "Robinson",
                                                  IsSuperUser = false
                                              });
            // Act
            var renderedText = template.ToString();

            // Assert
            Assert.AreEqual(renderedText, "Ian is a super user? False. But his last name is Robinson.");
        }

        [Test]
        public void ListIterator_MultipleItems()
        {
            // Arrange
            var template = new StringTemplate("$user:{ u | <p>$u.FirstName$ is a super user? $u.IsSuperUser$. But his last name is $u.LastName$.</p>}$");
            var user = new { FirstName = "Ian", LastName = "Robinson", IsSuperUser = false };
            var userList = (new[] {user}).ToList();
            userList.Add(new { FirstName = "Gertrude", LastName = "Schmuckbucket", IsSuperUser = true});

            template.SetAttribute("user", userList);

            // Act
            var renderedText = template.ToString();

            // Assert
            Assert.AreEqual(renderedText, "<p>Ian is a super user? False. But his last name is Robinson.</p><p>Gertrude is a super user? True. But his last name is Schmuckbucket.</p>");
        }

        [Test]
        public void ListIterator_MultipleItems_ConditionalTemplate()
        {
            // Arrange
            var template = new StringTemplate("$user:{ u | <p>$u.FirstName$ is a super user? $u.IsSuperUser$. But $if(u.IsFemale)$her$else$his$endif$ last name is $u.LastName$.</p>}$");

            var user = new { FirstName = "Ian", LastName = "Robinson", IsFemale = false, IsSuperUser = false };
            var userList = (new[] { user }).ToList();
            userList.Add(new { FirstName = "Gertrude", LastName = "Schmuckbucket", IsFemale = true, IsSuperUser = true });

            template.SetAttribute("user", userList);

            // Act
            var renderedText = template.ToString();

            // Assert
            Assert.AreEqual(renderedText, "<p>Ian is a super user? False. But his last name is Robinson.</p><p>Gertrude is a super user? True. But her last name is Schmuckbucket.</p>");
        }
    }
}