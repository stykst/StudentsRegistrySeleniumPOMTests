using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace StudentsRegistrySeleniumPOMTests.Tests
{
    public class BaseTest
    {
        protected  IWebDriver driver;

        [OneTimeSetUp]
        public void Setup() 
        { 
            driver = new ChromeDriver(); 
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
