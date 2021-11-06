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

        /// <summary>
        /// Test case:
        /// 1. Open link http://automationpractice.com/index.php
        /// 2. Move your cursor over Women's link.
        /// 3. Click on sub menu 'T-shirts'
        /// 4. Get Name/Text of the first product displayed on the page. 
        /// 5. Now enter the same product name in the search bar present on top of page and click search button.
        /// 6. Validate that same product is displayed on searched page with same details which were displayed on T-Shirt's page.
        ///     Test case do not mention which detail field need to check so we check: productID to make sure it is same item. 
        ///     For detail: check the image source, lablel and prise 

        /// </summary>
        [Test]
        public void SearchProduct_ShouldSuccess()
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
