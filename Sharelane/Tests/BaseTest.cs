using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sharelane.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharelane.Tests
{
    internal class BaseTest
    {
        protected WebDriver ChromeDriver { get; set; }
        public SignUpPage SignUpPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public CredentialsPage CredentialsPage { get; set; }


        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            SignUpPage = new SignUpPage(ChromeDriver);
            LoginPage = new LoginPage(ChromeDriver);
            CredentialsPage = new CredentialsPage(ChromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
