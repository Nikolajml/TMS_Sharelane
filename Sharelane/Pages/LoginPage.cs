using OpenQA.Selenium;
using Sharelane.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharelane.Pages
{
    internal class LoginPage : BasePage
    {        
        By EmailInputLocator = By.Name("email");
        By PasswordInputLocator = By.Name("password");
        By LoginClickLocator = By.XPath("//input[@value='Login']");
        By HelloMessageLocator = By.XPath("//span[@class='user']");

        public LoginPage(WebDriver driver) : base(driver)
        {
        }

        public void SetEmail(string email)
        {
            ChromeDriver.FindElement(EmailInputLocator).SendKeys(email);
        }

        public void SetPassword(string password)
        {
            ChromeDriver.FindElement(PasswordInputLocator).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            ChromeDriver.FindElement(LoginClickLocator).Click();
        }

        public bool CheckHelloMessage()
        {
            return ChromeDriver.FindElement(HelloMessageLocator).Displayed;
        }

        public void Login(string email = "", string password = "")
        {
            SetEmail(email);
            SetPassword(password); 
            ClickLoginButton();
        }
    }
}
