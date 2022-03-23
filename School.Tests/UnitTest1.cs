using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace School.Tests
{
    public class StudentClassShould
    {
        private Student student;
        private Student student2;

        [SetUp]
        public void Setup()
        {
            student = new Student();
            student2 = new Student();

            student.Name = "StudentName";

        }

        [Test]
        public void ReturnsIdBetween10000And99999()
        {
            bool flag = student.Id >= 10000 && student.Id <= 99999;

            Assert.IsTrue(flag);
        }
        [Test]
        public void ReturnsCorrectName()
        {
            var actualName = student.Name;

            Assert.AreEqual("StudentName", actualName);
        }

        [Test]
        public void ReturnsExeptionMessage_When_NameIsEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => student.Name = "   ");

            Assert.AreEqual("Name should not be empty!", ex.Message);

        }

        [Test]
        public void ReturnsExeptionMessage_When_NameIsNull()
        {
            var ex = Assert.Throws<NullReferenceException>(() => student.Name = null);

            Assert.AreEqual("Name should not be empty!", ex.Message);
        }


    }

    public class CourseClassShould
    {
        private Course course;
        private Student student;

        [SetUp]
        public void Setup()
        {
            course = new Course();
            course.Name = "QA";

            student = new Student();
            student.Name = "StudentName";

        }

        [Test]
        public void ReturnsCorrectCourseName()
        {
            var actualCourseName = course.Name;
            Assert.AreEqual("QA", actualCourseName);
        }
        [Test]
        public void StudentIsSuccessfullyAddedToTheCourse()
        {
            var expectedList = new List<Student>();
            expectedList.Add(student);

            course.addStudentToTheCourse(student);


            CollectionAssert.AreEqual(expectedList, course.Students);
        }
        [Test]
        public void StudentIsSuccessfullyDeletedFromTheCourse()
        {

            var studentsList = new List<Student>();
            studentsList.Add(student);

            var newStudent = new Student();
            newStudent.Name = "NewStudent2";
            course.addStudentToTheCourse(student);
            course.addStudentToTheCourse(newStudent);

            course.deleteStudentFromACourse(student);

            bool isThere = course.Students.Contains(student);
            Assert.IsFalse(isThere);


        }
        [Test]
        public void ReturnsCorrectExeptionMessageWhenStudentIsNotInTheCourseList_When_IsToDelete()
        {
            course.addStudentToTheCourse(student);
            course.deleteStudentFromACourse(student);


            var ex = Assert.Throws<Exception>(() => course.deleteStudentFromACourse(student));

            Assert.AreEqual("There is no such a student in the cource", ex.Message);

        }
        [Test]
        public void ReturnsCorrectExeptionMessageIfThereIsNoSpaceInTheCourse_When_StudentIsAdded()
        {

            var student2 = new Student();
            student2.Name = "NameTest2";
            var student3 = new Student();
            student3.Name = "NameTest3";
            course.addStudentToTheCourse(student);
            course.addStudentToTheCourse(student2);


            var ex = Assert.Throws<Exception>(() => course.addStudentToTheCourse(student3));

            Assert.AreEqual("The course is fully booked", ex.Message);

        }

        [Test]
        public void DoesNotAddStudentTwice()
        {
            course.addStudentToTheCourse(student);
            course.addStudentToTheCourse(student);

            Assert.AreEqual(1, course.Students.Count);
        }

    }
    public class SchoolClassShould
    {


        [Test]
        [Author ("Yulia Starostenko")]
        public void ReturnsCorrectListOfCourses_When_Added()
        {
            var school = new School();
            Course course1 = new()
            {
                Name = "test1"
            };
            Course course2 = new()
            {
                Name = "test2"
            };


            school.Courses.Add(course1);
            school.Courses.Add(course2);

            var listOfCourses = new List<Course>();
            listOfCourses.Add(course1);
            listOfCourses.Add(course2);

            CollectionAssert.AreEqual(listOfCourses, school.Courses);
        }
    }
}