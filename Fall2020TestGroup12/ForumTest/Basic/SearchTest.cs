using System;
using System.Collections.Generic;
using System.Text;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12.Data;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.ViewModels;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.CourseModel;

namespace Fall2020TestGroup12.ForumTest.Basic
{
    public class SearchTest
    {

        // Search unit test components: 
        // 1. Interface objects
        // 2. Unit Tests
        // 3. Mock Data

        // 1. Interface Objects

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
        private MockData mockData;

        public SearchTest()
        {
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            mockResponseRepo = new Mock<IResponseRepo>();
            mockCommentRepo = new Mock<ICommentRepo>();
            courseController = new CourseController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            responseController = new ResponseController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            commentController = new CommentController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);

            mockData = new MockData();
        }

        // 2. Unit Tests
        [Fact]
        public void ShouldListAllDepartments()
        {
            // Arrange
            List<Department> mockDepartments = mockData.CreateMockDepartmentData();
            mockDepartmentRepo.Setup(m => m.ListAllDepartments()).Returns(mockDepartments);
            departmentController = new DepartmentController(mockDepartmentRepo.Object);
            int expectedNumberOfDeptsInList = 4;

            // Act
            ViewResult result = departmentController.ListAllDepartments() as ViewResult;
            List<Department> resultModel = result.Model as List<Department>;
            int actualNumberOfDeptsInList = resultModel.Count;

            // Assert
            Assert.Equal(expectedNumberOfDeptsInList, actualNumberOfDeptsInList);

        }


        [Fact]
        public void ShouldListAllCourses()
        {
            // #1 Arange
            List<Course> mockCourses = mockData.CreateMockCourseData();
            mockCourseRepo.Setup(m => m.ListAllCourses()).Returns(mockCourses);
            courseController = new CourseController(null, mockCourseRepo.Object);
            int expectedNumberOfCoursesInList = 3;

            // #2 Act
            ViewResult result = courseController.ListAllCourses() as ViewResult;
            List<Course> resultModel = result.Model as List<Course>;
            int actualNumberOfCoursesInList = resultModel.Count;

            // #3 Assert
            Assert.Equal(expectedNumberOfCoursesInList, actualNumberOfCoursesInList);

        }


        [Fact]
        public void ShouldListAllDiscussions()
        {
            // Arrange
            List<Discussion> mockDiscussions = mockData.CreateMockDiscussionData();
            mockDiscussionRepo.Setup(m => m.ListAllDiscussions()).Returns(mockDiscussions);
            discussionController = new DiscussionController(null, null, mockDiscussionRepo.Object);
            int expectedNumberOfDiscussionsInList = 3;

            // Act
            ViewResult result = discussionController.ListAllDiscussions() as ViewResult;
            List<Discussion> resultModel = result.Model as List<Discussion>;
            int actualNumberOfDiscussionsInList = resultModel.Count;

            // Assert
            Assert.Equal(expectedNumberOfDiscussionsInList, actualNumberOfDiscussionsInList);

        }


        [Fact]
        public void ShouldListAllResponses()
        {
            // Arrange
            List<Response> mockResponses = mockData.CreateMockResponseData();
            mockResponseRepo.Setup(m => m.ListAllResponses()).Returns(mockResponses);
            responseController = new ResponseController(null, null, null, mockResponseRepo.Object);
            int expectedNumberOfResponsesInList = 5;

            // Act
            ViewResult result = responseController.ListAllResponses() as ViewResult;
            List<Response> resultModel = result.Model as List<Response>;
            int actualNumberOfResponsesInList = resultModel.Count;

            // Assert
            Assert.Equal(expectedNumberOfResponsesInList, actualNumberOfResponsesInList);
        }


        [Fact]
        public void ShouldListAllComments()
        {
            // Arrange
            List<Comment> mockComments = mockData.CreateMockCommentData();
            mockCommentRepo.Setup(m => m.ListAllComments()).Returns(mockComments);
            commentController = new CommentController(null, null, null, null, mockCommentRepo.Object);
            int expectedNumberOfCommentsInList = 5;

            // Act
            ViewResult result = commentController.ListAllComments() as ViewResult;
            List<Comment> resultModel = result.Model as List<Comment>;
            int actualNumberOfCommentsInList = resultModel.Count;

            // Assert
            Assert.Equal(expectedNumberOfCommentsInList, actualNumberOfCommentsInList);

        }


        //3. Mock Data

        // Moved to other class - more clean


    }
}
