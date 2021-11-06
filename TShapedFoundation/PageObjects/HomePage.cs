using OpenQA.Selenium;
using System;
using TShapedFoundation.Common;

namespace TShapedFoundation.PageObjects
{
    class HomePage : BasePage
    {

        private By SigninLink = By.CssSelector("a[class='login']");
        private By TshirtsLink = By.CssSelector("ul[class*='submenu-container'] a[title='T-shirts']");
        private By WomenLink = By.CssSelector("a[title='Women']");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public CreateAccountPage GoToCreateAccountPage()
        {
            ClickToElement(SigninLink);
            return new CreateAccountPage(driver);
        }

        public WomenTshirtsPage GoToWomenTshirtPage()
        {
            HoverAndClick(WomenLink, TshirtsLink);
            return new WomenTshirtsPage(driver);
        }
    }
}
