using OpenQA.Selenium;
using System;
using TShapedFoundation.Common;
using TShapedFoundation.Utilities;

namespace TShapedFoundation.PageObjects
{
    class CreateAccountPage : BasePage
    {

        private By EmailCreateInput = By.CssSelector("label[for='email_create']+input"); 
        private By SubmitCreateButton = By.Id("SubmitCreate"); 

        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public RegisterPage GotoCreateAccountInfoPage(string emailName, string emailAddress)
        {
            SendKeyToElement(EmailCreateInput, CommonUtilities.CreateEmailAddress(emailName, emailAddress));
            ClickToElement(SubmitCreateButton);
            return new RegisterPage(driver);
        }
    }
}
