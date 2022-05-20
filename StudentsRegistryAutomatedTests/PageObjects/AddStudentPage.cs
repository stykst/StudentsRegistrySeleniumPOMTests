using OpenQA.Selenium;

namespace StudentsRegistrySeleniumPOMTests.PageObjects
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => 
            "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldName =>
            driver.FindElement(By.CssSelector("input#name"));
        public IWebElement FieldEmail =>
            driver.FindElement(By.CssSelector("input#email"));
        public IWebElement ButtonSubmit =>
            driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement ElementErrorMsg =>
            driver.FindElement(By.XPath("//div[contains(@style,'background:red')]"));

        public void AddStudent(string name, string email)
        {
            FieldName.SendKeys(name);
            FieldEmail.SendKeys(email);
            ButtonSubmit.Click();
        }
    }
}
