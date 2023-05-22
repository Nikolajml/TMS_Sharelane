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
        public LoginPage LoginPage { get; set; }
        public CredentialsPage CredentialsPage { get; set; }

        [SetUp]
        public void Setup()
        {
            LoginPage = new LoginPage(ChromeDriver);
            CredentialsPage = new CredentialsPage(ChromeDriver);
        }
        [Test]
        public void Successful_LoginTest()
        {
            string email = CredentialsPage.GetEmail();
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(email, password);

            Assert.IsTrue(LoginPage.CheckHelloMessage());
        }
    }
}
