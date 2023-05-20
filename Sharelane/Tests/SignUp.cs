using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace Sharelane.Tests
{
    [TestFixture]
    internal class SignUpTest
    {
        WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/register.py");
        }

        [Test]
        public void Successful_SignUp_Test_ZipCodeMoreThanFiveNumber()
        {
            string zipCode = "12345";            

            ChromeDriver.FindElement(By.Name("zip_code")).SendKeys(zipCode);
            ChromeDriver.FindElement(By.XPath("//input[@value='Continue']")).Click();

            var registerButton = ChromeDriver.FindElement(By.XPath("//input[@value='Register']"));

            Assert.IsTrue(registerButton.Displayed);            
        }

        [Test]
        public void Unsuccessful_SignUp_Test_ZipCodeLessThanFifeNumbers_CheckErrorMessage()
        {
            string zipCode = "1234";
            string errorMessage = "Oops, error on page. ZIP code should have 5 digits";

            ChromeDriver.FindElement(By.Name("zip_code")).SendKeys(zipCode);
            ChromeDriver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            var actualErroreMessage = ChromeDriver.FindElement(By.XPath("//span[@class='error_message']"));

            Assert.AreEqual(actualErroreMessage.Text, errorMessage);
        }

        [Test]
        public void Successful_SignUp_Test_WithAllValidecredentials()
        {
            string zipCode = "12345";
            string firstName = "Ivan";
            string lastName = "Kivalev";
            string email = "index21test@yandex.ru";
            string password = "test1111";
            string confirmPassword = "test1111";
            string successMessage = "Account is created!";

            ChromeDriver.FindElement(By.Name("zip_code")).SendKeys(zipCode);
            ChromeDriver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            ChromeDriver.FindElement(By.Name("first_name")).SendKeys(firstName);
            ChromeDriver.FindElement(By.Name("last_name")).SendKeys(lastName);
            ChromeDriver.FindElement(By.Name("email")).SendKeys(email);
            ChromeDriver.FindElement(By.XPath("//input[@name='password1']")).SendKeys(password);
            ChromeDriver.FindElement(By.XPath("//input[@name='password2']")).SendKeys(confirmPassword);
            ChromeDriver.FindElement(By.XPath("//input[@value='Register']")).Click();
                        
            var actualSuccessMessage = ChromeDriver.FindElement(By.XPath("//span[@class='confirmation_message']"));

            Assert.AreEqual(actualSuccessMessage.Text, successMessage);


        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}