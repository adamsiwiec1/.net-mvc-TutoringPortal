using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorModel;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.TicketTest.Basic
{
    public class AddDeleteTest
    {
        private Mock<ITicketRepo> mockTicketRepo;
        private Mock<ITutorRepo> mockTutorRepo;
        private Mock<IStudentRepo> mockStudentRepo;
        private Mock<ICourseRepo> mockCourseRepo;
        private TicketController ticketController;

        public AddDeleteTest(ICourseRepo courseRepo)
        {
            mockTicketRepo = new Mock<ITicketRepo>();
            mockTutorRepo = new Mock<ITutorRepo>();
            mockStudentRepo = new Mock<IStudentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            ticketController = new TicketController(mockTicketRepo.Object, mockTutorRepo.Object, mockStudentRepo.Object);
        }
        [Fact]
        public void ShouldAddTicket()
        {
            // Arrange
            string studentId = "1";
            string tutorId = "2";
            Course course = new Course("TEST 100", "Course in department one", 1);
            course.CourseID = 1;
            mockCourseRepo.Setup(x => x.FindCourse(course.CourseID)).Returns(course);

            Ticket ticket = new Ticket("Test Ticket", null, null, null, studentId, tutorId, "Open", null, null, false, course.CourseID, (ICourseRepo)mockCourseRepo);
            mockTicketRepo.Setup(mockTicketRepo => mockTicketRepo.AddTicket(ticket));


            // Act
            ticketController.AddTicket(ticket);

            // Assert
            mockTicketRepo.Verify(m => m.AddTicket(ticket), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddTicket()
        {
            // Arrange
            Ticket ticket = new Ticket();
            string expectedErrorMessage1 = "You must enter a ticket name.";
            string expectedErrorMessage2 = "Ticket status must be set.";
            string expectedErrorMessage3 = "Course code is required.";
            string expectedErrorMessage4 = "A ticket must be assigned to a student.";

            var validationResult = new List<ValidationResult>();
            // Act
            bool isValid = Validator.TryValidateObject(ticket, new ValidationContext(ticket), validationResult);

            string actualErrorMessage1 = validationResult[0].ErrorMessage;
            string actualErrorMessage2 = validationResult[1].ErrorMessage;
            string actualErrorMessage3 = validationResult[2].ErrorMessage;
            string actualErrorMessage4 = validationResult[3].ErrorMessage;

            // Assert
            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage1);
            Assert.Equal(expectedErrorMessage2, actualErrorMessage2);
            Assert.Equal(expectedErrorMessage3, actualErrorMessage3);
            Assert.Equal(expectedErrorMessage4, actualErrorMessage4);
        }

        [Fact]
        public void ShouldDeleteTicket()
        {
            // Arange
            string studentId = "1";
            string tutorId = "2";
            int courseID = 1;
            Ticket ticket = new Ticket("Test Ticket", null, null, null, "001", tutorId, "Open", null, null, false, courseID);
            mockTicketRepo.Setup(m => m.DeleteTicket(It.IsAny<Ticket>()));

            // Act
            ticketController.DeleteTicket(ticket);

            // Assert
            mockTicketRepo.Verify(m => m.DeleteTicket(ticket), Times.Exactly(1));
        }

    }
}
