using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.ForumTest.Basic
{
    public class AddDeleteTest
    {

        private Mock<IDepartmentRepo> mockDepartmentRepo;
        private Mock<ICourseRepo> mockCourseRepo;
        private Mock<IDiscussionRepo> mockDiscussionRepo;
        private Mock<IResponseRepo> mockResponseRepo;
        private Mock<ICommentRepo> mockCommentRepo;
        private DepartmentController departmentController;
        private CourseController courseController;
        private DiscussionController discussionController;
        private ResponseController responseController;
        private CommentController commentController;

        public AddDeleteTest()
        {
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            mockResponseRepo = new Mock<IResponseRepo>();
            mockCommentRepo = new Mock<ICommentRepo>();

            departmentController = new DepartmentController(mockDepartmentRepo.Object);
            courseController = new CourseController(null, mockCourseRepo.Object);
            discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            responseController = new ResponseController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            commentController = new CommentController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
        }


        [Fact]
        public void ShouldAddNewDepartment()
        {
            Department department = new Department("Department Title", "Department Description");
            mockDepartmentRepo.Setup(mockDepartmentRepo => mockDepartmentRepo.AddDepartment(department));

            departmentController.AddDepartment(department);

            mockDepartmentRepo.Verify(m => m.AddDepartment(department), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddNewDepartment()
        {
            Department department = new Department();
            string expectedErrorMessage1 = "Department Name cannot be left blank.";
            string expectedErrorMessage2 = "Department Description cannot be left blank.";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(department, new ValidationContext(department), validationResult);

            string actualErrorMessage1 = validationResult[0].ErrorMessage;
            string actualErrorMessage2 = validationResult[1].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage1);
            Assert.Equal(expectedErrorMessage2, actualErrorMessage2);
        }

        [Fact]
        public void ShouldDeleteDepartment()
        {
            // Arange
            Department department = new Department("Department Title", "Department Description");
            mockDepartmentRepo.Setup(m => m.DeleteDepartment(It.IsAny<Department>()));

            // Act
            departmentController.DeleteDepartment(department);

            // Assert
            mockDepartmentRepo.Verify(m => m.DeleteDepartment(department), Times.Exactly(1));
        }

        [Fact]
        public void ShouldAddNewCourse()
        {
            Course course = new Course("Course Title", "Course Description", 001);
            mockCourseRepo.Setup(mockCourseRepo => mockCourseRepo.AddCourse(course));

            courseController.AddCourse(course);

            mockCourseRepo.Verify(m => m.AddCourse(course), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddNewCourse()
        {

            Course course = new Course();
            string expectedErrorMessage1 = "Code Code cannot be left blank.";
            string expectedErrorMessage2 = "Course Description cannot be left blank.";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(course, new ValidationContext(course), validationResult);

            string actualErrorMessage1 = validationResult[0].ErrorMessage;
            string actualErrorMessage2 = validationResult[1].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage1);
            Assert.Equal(expectedErrorMessage2, actualErrorMessage2);
        }



        [Fact]
        public void ShouldDeleteCourse()
        {
            // Arange
            int deptId = 1;
            Course course = new Course("Course Code", "Course Description", deptId);
            mockCourseRepo.Setup(m => m.DeleteCourse(It.IsAny<Course>()));

            // Act
            courseController.DeleteCourse(course);

            // Assert
            mockCourseRepo.Verify(m => m.DeleteCourse(course), Times.Exactly(1));
        }

        [Fact]
        public void ShouldAddNewDiscussion()
        {
            Discussion discussion = new Discussion("Test Discussion Title", "Test Description", DateTime.Now, 001, "00001");
            mockDiscussionRepo.Setup(mockDiscussionRepo => mockDiscussionRepo.AddDiscussion(discussion));

            discussionController.AddDiscussion(discussion);

            mockDiscussionRepo.Verify(m => m.AddDiscussion(discussion), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddNewDiscussion()
        {

            Discussion discussion = new Discussion();
            string expectedErrorMessage1 = "Discussion Title cannot be left blank.";
            string expectedErrorMessage2 = "Discussion Description cannot be left blank.";
            string expectedErrorMessage3 = "The ApplicationUserID field is required.";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(discussion, new ValidationContext(discussion), validationResult);

            string actualErrorMessage = validationResult[0].ErrorMessage;
            string actualErrorMessage2 = validationResult[1].ErrorMessage;
            string actualErrorMessage3 = validationResult[2].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage);
            Assert.Equal(expectedErrorMessage2, actualErrorMessage2);
            Assert.Equal(expectedErrorMessage3, actualErrorMessage3);

        }


        [Fact]
        public void ShouldDeleteDiscussion()
        {
            // Arange
            DateTime dateCreated = DateTime.Now;
            int courseId = 1;
            string authorId = "2";
            Discussion discussion = new Discussion("Discussion Title", "Discussion Description", dateCreated, courseId, authorId);
            mockDiscussionRepo.Setup(m => m.DeleteDiscussion(It.IsAny<Discussion>()));

            // Act
            discussionController.DeleteDiscussion(discussion);

            // Assert
            mockDiscussionRepo.Verify(m => m.DeleteDiscussion(discussion), Times.Exactly(1));
        }


        [Fact]
        public void ShouldAddNewResponse()
        {
            Response response = new Response("Response Title", "Response Body", 1, "001");
            mockResponseRepo.Setup(mockResponseRepo => mockResponseRepo.AddResponse(response));

            responseController.AddResponse(response);

            mockResponseRepo.Verify(m => m.AddResponse(response), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddNewResponse()
        {

            Response response = new Response();
            string expectedErrorMessage1 = "The Title field is required.";
            string expectedErrorMessage2 = "The Body field is required.";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(response, new ValidationContext(response), validationResult);

            string actualErrorMessage1 = validationResult[0].ErrorMessage;
            string actualErrorMessage2 = validationResult[1].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage1);
            Assert.Equal(expectedErrorMessage2, actualErrorMessage2);
        }


        [Fact]
        public void ShouldDeleteResponse()
        {
            // Arange
            int discussionId = 1;
            Response response = new Response("Response Title", "Response Body", discussionId, "001");
            mockResponseRepo.Setup(m => m.DeleteResponse(It.IsAny<Response>()));

            // Act
            responseController.DeleteResponse(response);

            // Assert
            mockResponseRepo.Verify(m => m.DeleteResponse(response), Times.Exactly(1));
        }

        [Fact]
        public void ShouldAddNewComment()
        {
            Comment comment = new Comment("This is a comment", 200, "001");
            mockCommentRepo.Setup(mockCommentRepo => mockCommentRepo.AddComment(comment));

            commentController.AddComment(comment);

            mockCommentRepo.Verify(m => m.AddComment(comment), Times.Exactly(1));
        }

        [Fact]
        public void ShouldNotAddNewComment()
        {
            Comment comment = new Comment();
            string expectedErrorMessage1 = "Your comment must contain at least one character.";

            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(comment, new ValidationContext(comment), validationResult);

            string actualErrorMessage1 = validationResult[0].ErrorMessage;

            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage1, actualErrorMessage1);
        }


        [Fact]
        public void ShouldDeleteComment()
        {
            // Arange
            int responseId = 1;
            Comment comment = new Comment("Test Comment", responseId, "001");
            mockCommentRepo.Setup(m => m.DeleteComment(It.IsAny<Comment>()));

            // Act
            commentController.DeleteComment(comment);

            // Assert
            mockCommentRepo.Verify(m => m.DeleteComment(comment), Times.Exactly(1));
        }
    }
}
