using OpenQA.Selenium;
using System.Linq;
using TShapedFoundation.Common;
using TShapedFoundation.Utilities;

namespace TShapedFoundation.PageObjects
{
    class SearchResultPage : BasePage
    {
        private By FirstProductMatchNameLink = By.CssSelector("li[class*='first-item-of-tablet-line'] a[class='product-name']");
        private By FirstProductMatchImage = By.CssSelector("li[class*='first-item-of-tablet-line'] img");
        private By FirstProductMatchPriceText = By.CssSelector("li[class*='first-item-of-tablet-line'] div[class='right-block'] span[class='price product-price']");
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetProductId()
        {
            var products = FindElement(FirstProductMatchNameLink);
            return CommonUtilities.GetQueryParam(products.GetAttribute(Constant.AttributeName.Href), Constant.QueryParameter.ProductId);
        }

        public string GetFirstProductName()
        {
            WaitForElementExists(FirstProductMatchNameLink);
            return GetElementText(FirstProductMatchNameLink);
        }

        public string GetImageSource()
        {
            return GetElementAttributeText(FirstProductMatchImage, Constant.AttributeName.Src);
        }

        public string GetFirstProductPriceText()
        {
            return GetElementText(FirstProductMatchPriceText);
        }
    }
}
