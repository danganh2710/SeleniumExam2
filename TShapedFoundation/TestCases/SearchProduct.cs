using NUnit.Framework;
using OpenQA.Selenium;
using TShapedFoundation.Common;
using TShapedFoundation.PageObjects;
using System.Configuration;

namespace TShapedFoundation.TestCases
{
    [TestFixture]
    class SearchProduct : WebDriverManagers
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
            homePage = new HomePage(driver);
            var womenTshirtPage =  homePage.GoToWomenTshirtPage();
            var womenProductName = womenTshirtPage.GetFirstProductName();
            var womenImageSrc = womenTshirtPage.GetImageSource();
            var womenPrice = womenTshirtPage.GetFirstProductPriceText();
            var womenProductId = womenTshirtPage.GetProductId();


            var searchResultPage = womenTshirtPage.SearchProduct(womenProductName);
            var searchProductName = searchResultPage.GetFirstProductName();
            var searchImageSrc = searchResultPage.GetImageSource();
            var searchPrice = searchResultPage.GetFirstProductPriceText();
            var searchProductId = searchResultPage.GetProductId();

            Assert.True(womenProductId.Equals(searchProductId)&&womenProductName.Equals(searchProductName)&& womenImageSrc.Equals(searchImageSrc)&& womenPrice.Equals(searchPrice));
        }
    }
}
