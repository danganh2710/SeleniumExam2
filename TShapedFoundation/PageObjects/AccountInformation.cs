using OpenQA.Selenium;
using TShapedFoundation.Common;

namespace TShapedFoundation.PageObjects
{
    class AccountInformation : BasePage
    {
        private By AccountSpan = By.CssSelector("a[class='account'] span");

        public AccountInformation(IWebDriver driver) : base(driver)
        {
        }

        public string GetUserLoginName()
        {
            WaitForElementExists(AccountSpan);
            return GetElementText(AccountSpan);
        }
    }
}