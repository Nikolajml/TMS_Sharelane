using NUnit.Framework;
using Sharelane.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharelane.Tests
{
    [TestFixture]
    internal class LoginTest : BaseTest
    {                     
        [Test]
        public void Successful_LoginTest()
        {
            string email = CredentialsPage.GetEmail();
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(email, password);

            Assert.IsTrue(LoginPage.CheckHelloMessage());
        }

        [Test] 
        public void Unsuccessful_LoginTest_CheckErrorMessage()
        {
            string expectedErrorMessage = "Oops, error. Email and/or password don't match our records";            
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(password: password);

            Assert.That(LoginPage.CheckErrorMessage, Is.EqualTo(expectedErrorMessage));
        }
    }
}
