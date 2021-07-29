using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020TestGroup12;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.TicketTest.Basic
{
    public class SearchTest
    {
        private Mock<ITicketRepo> mockTicketRepo;
        private Mock<IMajorRepo> mockMajorRepo;
        private Mock<ITutorRepo> mockTutorRepo;
        private Mock<IStudentRepo> mockStudentRepo;
        private Mock<ICourseRepo> mockCourseRepo;
        private Mock<ITutorCourseRepo> mockTutorCourseRepo;
        private Mock<IDepartmentRepo> mockDepartmentRepo;
        private TutorCourseController tutorCourseController;
        private MockData mockData;

        public SearchTest()
        {
            mockTutorRepo = new Mock<ITutorRepo>();
            mockTutorCourseRepo = new Mock<ITutorCourseRepo>();
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockMajorRepo = new Mock<IMajorRepo>();

            tutorCourseController = new TutorCourseController(mockTutorCourseRepo.Object);

            mockData = new MockData();
        }


        [Fact]
        public void ShouldListAllTickets()
        {
            mockTicketRepo = new Mock<ITicketRepo>();
            mockTutorRepo = new Mock<ITutorRepo>();
            mockStudentRepo = new Mock<IStudentRepo>();
            mockTutorCourseRepo = new Mock<ITutorCourseRepo>();

            List<Ticket> mockTickets = mockData.CreateMockTicketData();
            mockTicketRepo.Setup(m => m.ListAllTickets()).Returns(mockTickets);
            List<Tutor> mockTutors = mockData.CreateMockTutorData();
            mockTutorRepo.Setup(m => m.ListAllTutors()).Returns(mockTutors);
            List<Student> mockStudents = mockData.CreateMockStudentData();
            mockStudentRepo.Setup(m => m.ListAllStudents()).Returns(mockStudents);


            int expectedNumberOfTicketsInList = 4;
            TicketController ticketController = new TicketController(mockTicketRepo.Object, mockTutorRepo.Object, mockStudentRepo.Object);

            tutorCourseController = new TutorCourseController(mockTutorCourseRepo.Object);

            ViewResult result = ticketController.ListAllTickets() as ViewResult;
            List<Ticket> resultModel = result.Model as List<Ticket>;
            int actualNumberOfTicketsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTicketsInList, actualNumberOfTicketsInList);

        }

        [Fact]
        public void ShouldListAllMajors()
        {

            mockMajorRepo = new Mock<IMajorRepo>();

            List<Major> mockMajors = mockData.CreateMockMajorData();
            mockMajorRepo.Setup(m => m.ListAllMajors()).Returns(mockMajors);

            List<Department> mockDepartments = mockData.CreateMockDepartmentData();
            mockDepartmentRepo.Setup(m => m.ListAllDepartments()).Returns(mockDepartments);

            int expectedNumberOfMajorsInList = 5;
            MajorController majorController = new MajorController(mockMajorRepo.Object, mockDepartmentRepo.Object, mockTutorRepo.Object);

            ViewResult result = majorController.ListAllMajors() as ViewResult;
            List<Major> resultModel = result.Model as List<Major>;
            int actualNumberOfMajorsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfMajorsInList, actualNumberOfMajorsInList);

        }

        [Fact]
        public void ShouldListAllTutors()
        {

            mockTutorRepo = new Mock<ITutorRepo>();

            List<Tutor> mockTutors = mockData.CreateMockTutorData();
            mockTutorRepo.Setup(m => m.ListAllTutors()).Returns(mockTutors);

            List<Major> mockMajors = mockData.CreateMockMajorData();
            mockMajorRepo.Setup(m => m.ListAllMajors()).Returns(mockMajors);

            int expectedNumberOfTutorsInList = 2;
            TutorController tutorController = new TutorController(mockTutorRepo.Object, null, null, mockMajorRepo.Object);

            ViewResult result = tutorController.ListAllTutors() as ViewResult;
            List<Tutor> resultModel = result.Model as List<Tutor>;
            int actualNumberOfTutorsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTutorsInList, actualNumberOfTutorsInList);

        }

        [Fact]
        public void ShouldListAllTutorCourses()
        {

            List<TutorCourse> mockTutorCourses = mockData.CreateMockTutorCourseData();
            mockTutorCourseRepo.Setup(m => m.ListAllTutorCourses()).Returns(mockTutorCourses);

            int expectedNumberOfTutorCoursesInList = 5;

            ViewResult result = tutorCourseController.ListAllTutorCourses() as ViewResult;
            List<TutorCourse> resultModel = result.Model as List<TutorCourse>;
            int actualNumberOfTutorCoursesInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTutorCoursesInList, actualNumberOfTutorCoursesInList);
        }


        [Fact]
        public void ShouldListAllStudents()
        {

            mockStudentRepo = new Mock<IStudentRepo>();

            List<Student> mockStudents = mockData.CreateMockStudentData();
            mockStudentRepo.Setup(m => m.ListAllStudents()).Returns(mockStudents);

            int expectedNumberOfStudentsInList = 5;
            StudentController studentController = new StudentController(mockStudentRepo.Object, mockMajorRepo.Object);

            ViewResult result = studentController.ListAllStudents() as ViewResult;
            List<Student> resultModel = result.Model as List<Student>;
            int actualNumberOfStudentsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfStudentsInList, actualNumberOfStudentsInList);

        }


        // BIT MORE COMPLEX TICKET SEARCH FUNCTIONS

        [Fact]
        public void ShouldListAllOpenTickets()
        {
            mockTicketRepo = new Mock<ITicketRepo>();

            List<Ticket> mockTickets = mockData.CreateMockTicketData();
            mockTicketRepo.Setup(m => m.ListAllTickets()).Returns(mockTickets);

            int expectedNumberOfTicketsInList = 1;
            TicketController ticketController = new TicketController(mockTicketRepo.Object);

            ViewResult result = ticketController.ListAllOpenTickets() as ViewResult;
            List<Ticket> resultModel = result.Model as List<Ticket>;
            int actualNumberOfTicketsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTicketsInList, actualNumberOfTicketsInList);

        }

        [Fact]
        public void ShouldListAllInProgressTickets()
        {
            mockTicketRepo = new Mock<ITicketRepo>();

            List<Ticket> mockTickets = mockData.CreateMockTicketData();
            mockTicketRepo.Setup(m => m.ListAllTickets()).Returns(mockTickets);

            int expectedNumberOfTicketsInList = 2;
            TicketController ticketController = new TicketController(mockTicketRepo.Object);

            ViewResult result = ticketController.ListAllInProgressTickets() as ViewResult;
            List<Ticket> resultModel = result.Model as List<Ticket>;
            int actualNumberOfTicketsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTicketsInList, actualNumberOfTicketsInList);

        }

        [Fact]
        public void ShouldListAllClosedTickets()
        {

            mockTicketRepo = new Mock<ITicketRepo>();

            List<Ticket> mockTickets = mockData.CreateMockTicketData();
            mockTicketRepo.Setup(m => m.ListAllTickets()).Returns(mockTickets);

            int expectedNumberOfTicketsInList = 1;
            TicketController ticketController = new TicketController(mockTicketRepo.Object);

            ViewResult result = ticketController.ListAllClosedTickets() as ViewResult;
            List<Ticket> resultModel = result.Model as List<Ticket>;
            int actualNumberOfTicketsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTicketsInList, actualNumberOfTicketsInList);

        }


        //[Fact]
        //public void ShouldListAllQualifiedTutorsForCourse()
        //{

        //    mockTutorRepo = new Mock<ITutorRepo>();
        //    mockCourseRepo = new Mock<ICourseRepo>();

        //    List<Tutor> mockTutors = CreateMockTutorData();
        //    mockTutorRepo.Setup(m => m.ListAllTutors()).Returns(mockTutors);

        //    int courseID = 1;

        //    List<TutorCourse> mockTutorCourses = CreateMockTutorCourseData();
        //    mockCourseRepo.Setup(m => m.ListAllQualifiedTutors(courseID)).Returns(mockTutors);

        //    int expectedNumberOfTutorsInList = 4;
        //    CourseController courseController = new CourseController(null, mockCourseRepo.Object, null, null, null, mockTutorRepo.Object, null);

        //    ViewResult result = courseController.ListAllQualifiedTutors(courseID) as ViewResult;
        //    List<Tutor> resultModel = result.Model as List<Tutor>;
        //    int actualNumberOfTutorsInList = resultModel.Count;

        //    Assert.Equal(expectedNumberOfTutorsInList, actualNumberOfTutorsInList);

        //}

        // BIT MORE COMPLEX TUTOR SEARCH FUNCTIONS

        [Fact]
        public void ShouldListCoursesTutorIsQualifiedFor()
        {

            mockTutorRepo = new Mock<ITutorRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();

            Fall2020TestGroup12.ForumTest.Basic.SearchTest forumSearchTest = new Fall2020TestGroup12.ForumTest.Basic.SearchTest();

            List<Course> mockCourses = mockData.CreateMockCourseData();

            string tutorId = "1";

            List<TutorCourse> mockTutorCourses = mockData.CreateMockTutorCourseData();
            mockTutorRepo.Setup(m => m.ListAllQualifiedCourses(tutorId)).Returns(mockCourses);

            int expectedNumberOfTutorsInList = 3;
            TutorController tutorController = new TutorController(mockTutorRepo.Object);

            ViewResult result = tutorController.ListAllQualifiedCourses(tutorId) as ViewResult;
            List<Course> resultModel = result.Model as List<Course>;
            int actualNumberOfTutorsInList = resultModel.Count;

            Assert.Equal(expectedNumberOfTutorsInList, actualNumberOfTutorsInList);

        }





    }
}
