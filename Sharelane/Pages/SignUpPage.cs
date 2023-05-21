using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sharelane.Pages
{
    internal class SignUpPage : BasePage
    {   
        By ZipCodeLocator = By.Name("zip_code");
        By ContinueButton = By.XPath("//input[@value='Continue']");
        By FirstNameLocator = By.Name("first_name");
        By LastNameLocator = By.Name("last_name");
        By EmailLocator = By.Name("email");
        By PasswordLocator = By.XPath("//input[@name='password1']");
        By ConfirmPasswordLocator = By.XPath("//input[@name='password2']");
        By RegisterButtonLocator = By.XPath("//input[@value='Register']");
        By SuccessfulMessageLocator = By.XPath("//span[@class='confirmation_message']");
        By ErrorMessageLocator = By.XPath("//span[@class='error_message']");

        public SignUpPage(WebDriver driver) : base(driver) { }             

        public void SetZipCode(string zipCode)
        {
            ChromeDriver.FindElement(ZipCodeLocator).SendKeys(zipCode);
        }

        public void ClickContinueButton() 
        {
            ChromeDriver.FindElement(ContinueButton).Click();
        }

        public void SetFirstName(string firstName)
        {
            ChromeDriver.FindElement(FirstNameLocator).SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            ChromeDriver.FindElement(LastNameLocator).SendKeys(lastName);
        }

        public void SetEmail(string email)
        {
            ChromeDriver.FindElement(EmailLocator).SendKeys(email);
        }
        public void SetPassword(string password)
        {
            ChromeDriver.FindElement(PasswordLocator).SendKeys(password);
        }
        public void SetConfirmPassword(string confirmPassword)
        {
            ChromeDriver.FindElement(ConfirmPasswordLocator).SendKeys(confirmPassword);
        }
        public void ClickRegisterButton()
        {
            ChromeDriver.FindElement(RegisterButtonLocator).Click();
        }

        public string GetSuccessfulMessage()
        {
            return ChromeDriver.FindElement(SuccessfulMessageLocator).Text;
        }

        public void SignUp(string zipCode,string firstName, string lastName, string email, string password, string confirmPassword)
        {
            SetZipCode(zipCode);
            ClickContinueButton();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            SetConfirmPassword(confirmPassword);
            ClickRegisterButton();
        }

        public void SuccessfulZipCode(string zipCode)
        {
            SetZipCode(zipCode);
            ClickContinueButton();
        }
        
        public bool CheckRegisterButtonPresented()
        {
            return ChromeDriver.FindElement(RegisterButtonLocator).Displayed;
        }

        public string CheckErrorMessagePresented()
        {
            return ChromeDriver.FindElement(ErrorMessageLocator).Text;
        }
    }
}
