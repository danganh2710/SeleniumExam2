using OpenQA.Selenium;
using System;
using System.Web;
using TShapedFoundation.Common;
using TShapedFoundation.Utilities;

namespace TShapedFoundation.PageObjects
{
    class WomenTshirtsPage : BasePage
    {
        private By FirstProductNameLink = By.CssSelector("li[class*='first-item-of-tablet-line'] a[class='product-name']");
        private By FirstProductImage = By.CssSelector("li[class*='first-item-of-tablet-line'] img");
        private By FirstProductPriceText = By.CssSelector("li[class*='first-item-of-tablet-line'] div[class='right-block'] span[class='price product-price']");
        private By SearchInput = By.Id("search_query_top");
        private By SubmitSearchButton = By.CssSelector("button[name='submit_search']");

        public WomenTshirtsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetFirstProductName()
        {
            WaitForElementExists(FirstProductNameLink);
            return GetElementText(FirstProductNameLink);
        }

        public string GetImageSource()
        {
            return GetElementAttributeText(FirstProductImage, Constant.AttributeName.Src);
        }

        public string GetFirstProductPriceText()
        {
            return GetElementText(FirstProductPriceText);
        }

        public string GetProductId()
        {
            var products = FindElement(FirstProductNameLink);
            return CommonUtilities.GetQueryParam(products.GetAttribute(Constant.AttributeName.Href), Constant.QueryParameter.ProductId);
        }

        public SearchResultPage SearchProduct(string keyWord)
        {
            SendKeyToElement(SearchInput, keyWord);
            ClickToElement(SubmitSearchButton);
            return new SearchResultPage(driver);
        }
    }
}
