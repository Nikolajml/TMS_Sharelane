using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharelane.Pages
{
    internal class CredentialsPage : BasePage
    {
        By GetEmailLocator = By.XPath("//td[2]/b");

        public CredentialsPage(WebDriver driver) : base(driver)
        {
        }

        public void GoToUrlToGetEmail()
        {
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/register.py?page=2&zip_code=123456&first_name=qwe&last_name=qwe&email=nicolas.maliavko%40yandex.by&password1=qqqq&password2=%D0%B9%D0%B9%D0%B9%D0%B9");
        }

        public string GetEmailTroughUrl()
        {
            return ChromeDriver.FindElement(GetEmailLocator).Text;
        }

        public string GetEmail()
        {
            GoToUrlToGetEmail();
            return GetEmailTroughUrl();
        }

    }
}
