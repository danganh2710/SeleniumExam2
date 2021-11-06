using OpenQA.Selenium;
using TShapedFoundation.Common;
using TShapedFoundation.DataObjects;

namespace TShapedFoundation.PageObjects
{
    class RegisterPage : BasePage
    {

        private By FirstNameInput = By.Id("customer_firstname"); 
        private By LastNameInput = By.Id("customer_lastname"); 
        private By PasswordInput = By.Id("passwd");
        private By Address1Input = By.Id("address1");
        private By CityInput = By.Id("city");
        private By StateSelect = By.Id("id_state");
        private By PostcodeInput = By.Id("postcode");
        private By MobilePhoneInput = By.Id("phone_mobile");
        private By SubmitButton = By.Id("submitAccount");

        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        public AccountInformation RegisterNewAccount(CustomerRegisterModel customerModel)
        {
            WaitForElementExists(FirstNameInput);
            SendKeyToElement(FirstNameInput, customerModel.FirstName);
            SendKeyToElement(LastNameInput, customerModel.LastName);
            SendKeyToElement(PasswordInput, customerModel.Password);
            SendKeyToElement(Address1Input, customerModel.Address);
            SendKeyToElement(CityInput, customerModel.City);
            SelectDropDownList(StateSelect, customerModel.StateIndex);
            SendKeyToElement(PostcodeInput, customerModel.Postcode);
            SendKeyToElement(MobilePhoneInput, customerModel.MobilePhone);
            ClickToElement(SubmitButton);
            return new AccountInformation(driver);
        }
    }
}
