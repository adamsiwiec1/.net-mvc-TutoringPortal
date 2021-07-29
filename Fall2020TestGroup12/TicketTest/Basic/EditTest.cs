using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.TicketTest.Basic
{
    public class EditTest
    {
        private Mock<ITicketRepo> mockTicketRepo;
        private Mock<ITutorRepo> mockTutorRepo;
        private Mock<IStudentRepo> mockStudentRepo;
        private TicketController ticketController;

        public EditTest()
        {
            mockTicketRepo = new Mock<ITicketRepo>();
            mockTutorRepo = new Mock<ITutorRepo>();
            mockStudentRepo = new Mock<IStudentRepo>();
            ticketController = new TicketController(mockTicketRepo.Object,mockTutorRepo.Object, mockStudentRepo.Object);
        }


        [Fact]
        public void ShouldEditTicket()
        {
            // Arange
            string studentId = "1";
            string tutorId = "2";
            int courseID = 1;
            Ticket ticket = new Ticket("Test Ticket", null, null, null, studentId, tutorId, "Open", null, null, false, courseID);
            mockTicketRepo.Setup(m => m.EditTicket(It.IsAny<Ticket>()));

            // Act
            ticketController.EditTicket(ticket);

            // Assert
            mockTicketRepo.Verify(m => m.EditTicket(ticket), Times.Exactly(1));
        }

    }
}
