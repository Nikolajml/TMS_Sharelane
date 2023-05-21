using NUnit.Framework;
using OpenQA.Selenium;
using Sharelane.Pages;

namespace Sharelane.Tests
{
    [TestFixture]
    internal class SignUpTest : BaseTest
    {            
        [SetUp]
        public void Setup()
        {            
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/register.py");            
        }

        [Test]
        public void Successful_SignUp_Test_ZipCodeMoreThanFiveNumber()
        {
            string zipCode = "123455";

            SignUpPage.SuccessfulZipCode(zipCode);
            Assert.IsTrue(SignUpPage.CheckRegisterButtonPresented());            
        }

        [Test]
        public void Unsuccessful_SignUp_Test_ZipCodeLessThanFifeNumbers_CheckErrorMessage()
        {
            string zipCode = "1234";
            string errorMessage = "Oops, error on page. ZIP code should have 5 digits";

            SignUpPage.SuccessfulZipCode(zipCode);
            Assert.AreEqual(SignUpPage.CheckErrorMessagePresented(), errorMessage);            
        }

        [Test]
        public void Successful_SignUp_Test_WithAllValidecredentials()
        {
            string zipCode = "12345";
            string firstName = "Ivan";
            string lastName = "Kovalev";
            string email = "index21test@yandex.ru";
            string password = "test1111";
            string confirmPassword = "test1111";
            string successMessage = "Account is created!";

            SignUpPage.SignUp(zipCode, firstName, lastName, email, password, confirmPassword);

            Assert.That(SignUpPage.GetSuccessfulMessage, Is.EqualTo(successMessage));
        }        
    }
}