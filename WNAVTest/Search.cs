using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WNAVTest
{
    [TestClass]
    public class Search
    {
       
        [TestClass]
        public class SearchTests
        {
            private TestContext testContextInstance;
            private IWebDriver driver;
            private string appURL;
            private WebDriverWait wait;
            public SearchTests()
            {
              
            }

            [TestMethod]
            [TestCategory("Chrome")]
            public void VacationerSearchTest()
            {
                driver.Navigate().GoToUrl(appURL + "/");
                driver.FindElement(By.Id("where-to")).SendKeys("Upper Cape Cod");
                driver.FindElement(By.XPath("//*[@id='typeahead']/span/div/div/div")).Click();
                driver.FindElement(By.Id("SearchBar_btnSearch")).Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
                wait.Until(ExpectedConditions.TitleContains("Vacation Rental Search Results"));
                Assert.IsTrue(IsElementExists(By.XPath("//div[@id='map-listings-container']//div[@id='map-preview']/div[@id='searchResults']")), "Verified search by only where-to");
            }
            [TestMethod]
            [TestCategory("Chrome")]
            public void VacationerSearchByProperty()
            {
                driver.Navigate().GoToUrl(appURL + "/");
                driver.FindElement(By.Id("property_id")).SendKeys("1164");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement elementSearchBarBedrooms = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Header2010_propertyid_lookupR_btnGo2")));
                elementSearchBarBedrooms.Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
                wait.Until(ExpectedConditions.TitleContains("ID 1164"));
                Assert.IsTrue(IsElementExists(By.XPath("//*[@id='property-loc-desc']/span[@id='property-id'][contains(text(),'1164')]")), "Verified property id search");
            }

            
            [TestMethod]
            [TestCategory("Chrome")]
            public void VacationerSearchByDate()
            {
                driver.Navigate().GoToUrl(appURL + "/");
                driver.FindElement(By.Id("where-to")).SendKeys("Upper Cape Cod");
                driver.FindElement(By.XPath("//*[@id='typeahead']/span/div/div/div")).Click();
                WebElement date = (WebElement)driver.FindElement(By.XPath("//*[@id='SearchBar_arrive']"));
                date.SendKeys("08172023");
                driver.FindElement(By.Id("searchBarBedrooms")).Click();
                driver.FindElement(By.Id("SearchBar_searchBarBRMin")).SendKeys("1");
                driver.FindElement(By.Id("SearchBar_btnSearch")).Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
                wait.Until(driver => driver.Title.Contains("Vacation Rental Search Results") || driver.Title.Contains("No Properties found in Search"));
                Assert.IsTrue(IsElementExists(By.XPath("//div[@id='map-listings-container']//div[@id='map-preview']/div[@id='searchResults']")) || IsElementExists(By.XPath("//div[@id='search-results-noprop']//div[@id='searchResults']")) , "Verified search by only where-to");
            }
            private bool IsElementExists(By elementId)
            {
                try
                {
                    IWebElement elements = driver.FindElement(elementId);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
            // Custom ExpectedConditions-like method to check if an element is visible
            public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
            {
                return driver =>
                {
                    IWebElement element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                };
            }
            /// <summary>
            ///Gets or sets the test context which provides
            ///information about and functionality for the current test run.
            ///</summary>
            public TestContext TestContext
            {
                get
                {
                    return testContextInstance;
                }
                set
                {
                    testContextInstance = value;
                }
            }

            [TestInitialize()]
            public void SetupTest()
            {
                appURL = "https://wnavcape.weneedavacation.com";
                ChromeOptions chromeOptions = new ChromeOptions();
                //chromeOptions.AddArguments("headless");
                string browser = "Chrome";
                switch (browser)
                {
                    case "Chrome":
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "IE":
                        driver = new InternetExplorerDriver();
                        break;
                    default:
                        driver = new ChromeDriver(chromeOptions);
                        break;
                }

            }

            [TestCleanup()]
            public void MyTestCleanup()
            {
                driver.Quit();
            }
        }
    }
}
