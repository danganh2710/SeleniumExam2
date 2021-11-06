using NUnit.Framework;
using OpenQA.Selenium;
using TShapedFoundation.Common;
using TShapedFoundation.PageObjects;
using System.Configuration;
using TShapedFoundation.DataObjects;

namespace TShapedFoundation.TestCases
{
    [TestFixture]
    class RegisterAccount : WebDriverManagers
    {
        IWebDriver driver;
        HomePage homePage;
        

        [SetUp]
        public void Setup()
        {
            driver = CreateBrowserDriver("chrome");
            driver.Navigate().GoToUrl(Constant.AppUrl);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void LoginWithValidUser()
        {
            var customer = new CustomerRegisterModel()
            {
                FirstName = "Anh",
                LastName = "Hoang",
                Password = "Nashtech@123",
                Address = "6001 E Woodmen Rd, Colorado Springs, CO 80923, United States",
                City = "Colorado",
                StateIndex = 6,
                Postcode = "80923",
                MobilePhone = "012345678",
                EmailName="anhdangh",
                EamilAddressName = "@gmail.com"
            };

            homePage = new HomePage(driver);
            var createAccountPage = homePage.GoToCreateAccountPage();
            var createAccountPageInforPage = createAccountPage.GotoCreateAccountInfoPage(customer.EmailName, customer.EamilAddressName);
            var accountInforPage = createAccountPageInforPage.RegisterNewAccount(customer);
            string accountName = accountInforPage.GetUserLoginName();

            Assert.AreEqual(accountName, customer.FullName);
        }
    }
}
