using NUnit.Framework;
using StudentsRegistrySeleniumPOMTests.PageObjects;
using System;

namespace StudentsRegistrySeleniumPOMTests.Tests
{
    public class TestAddStudentPage : BaseTest
    {
        [Test]
        public void Test_AddStudentsPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());
            Assert.AreEqual("", page.FieldName.Text);
            Assert.AreEqual("", page.FieldEmail.Text);
            Assert.AreEqual("Add", page.ButtonSubmit.Text);
        }

        [Test]
        public void Test_AddStudentsPage_Links()
        {
            var page = new AddStudentPage(driver);
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

        [Test]
        public void Test_AddStudentsPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);

            page.Open();

            var name = "Pesho" + DateTime.Now.Ticks;
            var email = name + "@abc.bg";

            page.AddStudent(name, email);

            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());

            var students = viewStudentsPage.GetRegisteredStudents();
            var student = name + " (" + email + ")";            
            Assert.Contains(student, students);
        }

        [Test]
        public void Test_AddStudentsPage_TryToAddInvalidStudent()
        {
            var page = new AddStudentPage(driver);

            page.Open();

            var name = "";
            var email = "pesho@abc.bg";

            page.AddStudent(name, email);

            Assert.IsTrue(page.IsOpen());
            Assert.IsTrue(page.ElementErrorMsg.Text.Contains("Cannot add student"));
        }
    }
}