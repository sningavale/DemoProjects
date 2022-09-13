using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoLiberisProject
{
    public class Tests
    {
        IWebDriver driver;
        FrameworkChanges fmObject = new FrameworkChanges();

        // Web elements
        public IWebElement btnGetADemo => driver.FindElement(By.XPath("//*[@id='site-navigation']/div[@class='header-cta']/a"));
        public IWebElement labelSelectPartner => driver.FindElement(By.XPath("//*[@id='site-inner-wrapper']//div[@class='ph-submit-error']/div"));
        public IWebElement btnSubmitGetDemo => driver.FindElement(By.XPath("//*[@id='site-inner-wrapper']//a[@class='btn btn--medium js-partner-hero-button']"));

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\Shraddha\\source\\repos\\DemoLiberis\\DemoLiberisProject\\Drivers");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void NavigateToLiberis()
        {
            // Navigate to Liberis website
            driver.Url = "https://www.liberis.com/";

            // Click on Get Demo option
            btnGetADemo.Click();
            Thread.Sleep(2000);

            // Fetch Type of Partner  
            string labelTypeOfPartner = driver.FindElement(By.XPath("//*[@id=\"site-inner-wrapper\" ]//h4")).Text;
            IList<IWebElement> radioBtnList = driver.FindElements(By.XPath("//*[@id='site-inner-wrapper']//div[@class='radio_container']//input"));

            // Verify that we are on the partner selection page
            fmObject.VerifyString("Type of partner", labelTypeOfPartner);

            // Check radio button count
            if ( radioBtnList.Count == 3)
            {
                Console.WriteLine("On the Partner Selection Page and have 3 radio buttons");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            btnSubmitGetDemo.Click();

            string validationMessage = driver.FindElement(By.XPath("//*[@id='site-inner-wrapper']//div[@class='ph-submit-error']/div")).Text;

            // Verify Validation Message
            fmObject.VerifyString("Please select a type of partner", validationMessage);
        }

        [TearDown]
        public void closeBrower()
        {
            driver.Close();
        }
    }
}