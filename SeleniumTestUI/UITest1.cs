using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestUI
{
    [TestClass]
    public class UnitTest1
    {
        private const string url = "Remember to change this to the websites name!?!?";
        private IWebDriver driver;
        private IWebElement btnLightOn1;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(7000);
        }

        [TestMethod]
        public void TestSomeButton()
        {
            //Xpath can be found if you press f12 in google chrome and right clicks an element in the Elements and choose copy and full xpath.
            btnLightOn1 = driver.FindElement(By.XPath("SomeXPATH GOES HERE!?!"));

            btnLightOn1.Clear();
            btnLightOn1.SendKeys("SomeKeysHere");
            btnLightOn1.Click();
            if (btnLightOn1.Text != "this button works")
            {
                Assert.Fail();
            }
        }
    }
}
