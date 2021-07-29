using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020TestGroup12.TicketTest.Basic;
using Moq;
using Xunit;

namespace Fall2020TestGroup12.TicketTest.Complex
{
    public class AssignTicketTest
    {
        private Mock<ITicketRepo> mockTicketRepo;
        private Mock<ITutorRepo> mockTutorRepo;
        private Mock<ITutorCourseRepo> mockTutorCourseRepo;
        private Mock<IStudentRepo> mockStudentRepo;
        private Mock<ICourseRepo> mockCourseRepo;
        private Mock<IMajorRepo> mockMajorRepo;
        private TicketController ticketController;
        private MockData mockData;

        // te
        public AssignTicketTest()
        {
            mockTicketRepo = new Mock<ITicketRepo>();
            mockTutorRepo = new Mock<ITutorRepo>();
            mockTutorCourseRepo = new Mock<ITutorCourseRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockStudentRepo = new Mock<IStudentRepo>();
            mockMajorRepo = new Mock<IMajorRepo>();
            ticketController = new TicketController(mockTicketRepo.Object, mockTutorRepo.Object, mockStudentRepo.Object, mockCourseRepo.Object, mockTutorCourseRepo.Object, mockMajorRepo.Object);

            // Object of Forum Search Test Class - contains mock data. 
            mockData = new MockData();
        }

        [Fact]
        public void ShouldAssignQualifiedTutorToTicket() // Edit
        {

            // Arrange
            List<TutorCourse> mockTutorCourses = mockData.CreateMockTutorCourseData(); // Mock TutorCourse data from other Test class
            mockTutorCourseRepo.Setup(tc => tc.ListAllTutorCourses()).Returns(mockTutorCourses);

            string tutorId = null;
            int? courseID = 1;
            Ticket ticket = new Ticket("Test Ticket", null, null, null, "001", tutorId, "Open", null, null, false, courseID);
            ticket.TicketID = 1;
            mockTicketRepo.Setup(t => t.FindTicket(ticket.TicketID)).Returns(ticket);
            string expectedTutorId = "1";

            // Act
            ticketController.AssignQualifiedTutor(ticket.TicketID);

            // Assert
            mockTicketRepo.Verify(m => m.EditTicket(ticket), Times.Exactly(1));
            Assert.Equal(expectedTutorId, ticket.TutorId);

        }

        [Fact]
        public void ShouldNotAssignTutorToTicket() // Edit
        {

            // Arrange
            List<TutorCourse> mockTutorCourses = mockData.CreateMockTutorCourseData(); // Mock TutorCourse data from other Test class
            mockTutorCourseRepo.Setup(tc => tc.ListAllTutorCourses()).Returns(mockTutorCourses);

            string tutorId = null;
            int? courseID = 6;
            Ticket ticket = new Ticket("Test Ticket", "TEST 100", null, null, null, "001", tutorId, null, null, false, courseID);
            ticket.TicketID = 1;
            mockTicketRepo.Setup(t => t.FindTicket(ticket.TicketID)).Returns(ticket);

            // Act
            ticketController.AssignQualifiedTutor(ticket.TicketID);
            mockTicketRepo.Verify(m => m.EditTicket(ticket), Times.Exactly(0));

        }

    }
}
