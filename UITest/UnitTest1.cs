using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace UITest
{
    public class Tests
    {
        IWebDriver driver;

        [Test]
        public void Test1()
        {
            DriverOptions options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
            driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("W0wltc")).Click();
            driver.FindElement(By.CssSelector("textarea#APjFqb")).SendKeys("asd");
            driver.FindElement(By.CssSelector("textarea#APjFqb")).SendKeys(Keys.Enter);
            driver.Url.Should().Contain("q=asd");
        }

        [TearDown] 
        public void TearDown() 
        { 
            driver.Quit();
        }
    }
}
