using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Tabs
{
    class Pages
    {
        private IWebDriver driver;
        private By openMultipleWindowsTabs = By.XPath("//a[contains(text(),'Open Multiple Windows')]");
        private By openMultiplePages = By.XPath("//a[contains(text(),'Open multiple pages')]");
        private By firstWindowsLink = By.XPath("//a[contains(text(),'Open Window')]");
        private By imageFramesAndWindows = By.XPath("//img[@src=\"images/frames_windows.jpg\"]");

        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenMultipleWindows()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(openMultipleWindowsTabs));
            driver.FindElement(openMultipleWindowsTabs).Click();
            driver.SwitchTo().Frame(3);
            driver.FindElement(openMultiplePages).Click();
        }

        public bool CheckOpenThirdTabs()
        {
            bool result = false;

            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                driver.SwitchTo().ActiveElement();
                if (driver.Url.Contains("window3.html"))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void OpenFramesAndWindowsPage()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(imageFramesAndWindows));
            driver.FindElement(imageFramesAndWindows).Click();
        }
    }
}
