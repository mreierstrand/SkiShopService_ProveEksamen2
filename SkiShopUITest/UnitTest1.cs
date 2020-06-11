using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SkiShopUITest
{
    [TestClass]
    public class SkiShopUITest
    {

        private static readonly string DriverDirectory = "C:\\seleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }


        [TestMethod]
        public void TestGetAll()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement buttonElement = wait.Until(d => d.FindElement(By.Id("GetAllSkisButton")));
            buttonElement.Click();

            IWebElement SkiList = wait.Until(d => d.FindElement(By.Id("SkiListRow")));
            Assert.IsTrue(SkiList.Text.Contains("Slalom"));

        }

        [TestMethod]
        public void TestSearchFunction()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement buttonElement = wait.Until(d => d.FindElement(By.Id("GetAllSkisButton")));
            buttonElement.Click();

            IWebElement searchElement = wait.Until(d => d.FindElement(By.Id("myInput")));
            searchElement.Click();
            searchElement.SendKeys("Slalom");

            IWebElement SkiList = wait.Until(d => d.FindElement(By.Id("SkiListRow")));
            Assert.IsTrue(SkiList.Text.Contains("Slalom"));

        }

        [TestMethod]
        public void TestAdd()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            _driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            IWebElement buttonElement = wait.Until(d => d.FindElement(By.Id("GetAllSkisButton")));
            buttonElement.Click();

            IWebElement IdElement = wait.Until(d => d.FindElement(By.Id("addId")));
            IdElement.Click();
            IdElement.SendKeys("6");

            IWebElement SkiLengthElement = wait.Until(d => d.FindElement(By.Id("addSkiLength")));
            SkiLengthElement.Click();
            SkiLengthElement.SendKeys("200");

            IWebElement SkiTypeElement = wait.Until(d => d.FindElement(By.Id("addSkiType")));
            SkiTypeElement.Click();
            SkiTypeElement.SendKeys("Test");

            IWebElement PriceElement = wait.Until(d => d.FindElement(By.Id("addPrice")));
            PriceElement.Click();
            PriceElement.SendKeys("5000");


            IWebElement ButtonElement = wait.Until(d => d.FindElement(By.Id("addButton")));
            ButtonElement.Click();

            IWebElement SkiList = wait.Until(d => d.FindElement(By.Id("SkiListRow")));
            Assert.IsTrue(SkiList.Text.Contains("Test"));

        }
    }
}
