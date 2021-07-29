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
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.ForumTest.Basic
{
    public class EditTest
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

        public EditTest()
        {
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            mockResponseRepo = new Mock<IResponseRepo>();
            mockCommentRepo = new Mock<ICommentRepo>();

            departmentController = new DepartmentController(mockDepartmentRepo.Object);
            courseController = new CourseController(null, mockCourseRepo.Object);
            discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            responseController = new ResponseController(null, null, null, mockResponseRepo.Object);
            commentController = new CommentController(null, null, null, null, mockCommentRepo.Object);
        }

        [Fact]
        public void ShouldEditDepartment()
        {
            Department department = new Department("Test Department", "Test Descpription");
            department.DepartmentID = 20;
            mockDepartmentRepo.Setup(m => m.EditDepartment(It.IsAny<Department>()));

            departmentController.EditDepartment(department);

            mockDepartmentRepo.Verify(mockDepartmentRepo => mockDepartmentRepo.EditDepartment(department), Times.Exactly(1));

        }

        [Fact]
        public void ShouldEditCourse()
        {
            int deptId = 1;
            Course course = new Course("Course Code", "Course Description", deptId);
            mockCourseRepo.Setup(m => m.EditCourse(It.IsAny<Course>()));

            courseController.EditCourse(course);

            mockCourseRepo.Verify(mockCourseRepo => mockCourseRepo.EditCourse(course), Times.Exactly(1));

        }

        [Fact]
        public void ShouldEditDiscussion()
        {
            DateTime dateTime = new DateTime(2021, 3, 3);
            Discussion discussion = new Discussion("Discussion Test", "Description Test", dateTime, 3, "Test App Userid");
            discussion.DiscussionID = 20;
            mockDiscussionRepo.Setup(m => m.EditDiscussion(It.IsAny<Discussion>()));

            discussionController.EditDiscussion(discussion);

            mockDiscussionRepo.Verify(mockDiscussionRepo => mockDiscussionRepo.EditDiscussion(discussion), Times.Exactly(1));

        }

        [Fact]
        public void ShouldEditResponse()
        {
            int discussionID = 1;
            Response response = new Response("Response Title", "Response Body", discussionID, "001");
            mockResponseRepo.Setup(m => m.EditResponse(It.IsAny<Response>()));

            responseController.EditResponse(response);

            mockResponseRepo.Verify(mockResponseRepo => mockResponseRepo.EditResponse(response), Times.Exactly(1));

        }

        [Fact]
        public void ShouldEditComment()
        {
            int responseId = 1;
            Comment comment = new Comment("Comment Body", responseId, "001");
            mockCommentRepo.Setup(m => m.EditComment(It.IsAny<Comment>()));

            commentController.EditComment(comment);

            mockCommentRepo.Verify(mockCommentRepo => mockCommentRepo.EditComment(comment), Times.Exactly(1));

        }


    }
}
