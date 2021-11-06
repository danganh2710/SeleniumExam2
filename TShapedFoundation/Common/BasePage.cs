﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace TShapedFoundation.Common
{
    class BasePage
    {
        public IWebDriver driver;
        private IWebElement element;
        IList<IWebElement> elements;
        private WebDriverWait explicitWait;
        private readonly long longTimeout = Constant.longTimeout;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By byLocator)
        {
            return driver.FindElement(byLocator);
        }

        public IList<IWebElement> FindElements(By byLocator)
        {
            return driver.FindElements(byLocator);
        }

        public void ClickToElement(By byLocator)
        {
            this.FindElement(byLocator).Click();
        }

        public void SendKeyToElement(By byLocator, string value)
        {
            element = this.FindElement(byLocator);
            element.Clear();
            element.SendKeys(value);
        }

        public String GetElementText(By byLocator)
        {
            return this.FindElement(byLocator).Text;
        }

        public String GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public String GetElementAttributeText(By byLocator, string attributeName)
        {
            return this.FindElement(byLocator).GetAttribute(attributeName);
        }

        public void SleepInSeconds(int time)
        {
            try
            {
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException e)
            {
                e.StackTrace.ToString();

            }
        }

        public void SelectDropDownList(By byLocator, int index)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(byLocator));
            dropdown.SelectByIndex(index);
        }

        public void HoverAndClick(By elementToHoverLocator,
                         By elementToClickLocator)
        {
            Actions action = new Actions(driver);
            var elementToHover = FindElement(elementToHoverLocator);
            var elementToClick = FindElement(elementToClickLocator);
            action.MoveToElement(elementToHover).Click(elementToClick)
                  .Build().Perform();
        }


        public void WaitForElementVisible(By byLocator)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longTimeout));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byLocator));

        }

        public void WaitForElementExists(By byLocator)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longTimeout));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(byLocator));

        }

        public void WaitForElementInvisible(By byLocator)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longTimeout));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(byLocator));
        }
        public void WaitForElementClickable(By byLocator)
        {
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(longTimeout));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byLocator));
        }
    }
        
}
