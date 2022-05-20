using NUnit.Framework;
using StudentsRegistrySeleniumPOMTests.PageObjects;

namespace StudentsRegistrySeleniumPOMTests.Tests
{
    public class TestViewStudentsPage : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
            Assert.AreEqual("Students", page.GetPageTitle());
            Assert.AreEqual("Registered Students", page.GetPageHeadingText());

            var students = page.GetRegisteredStudents();
            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.IndexOf(")") == student.Length - 1);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }
    }
}