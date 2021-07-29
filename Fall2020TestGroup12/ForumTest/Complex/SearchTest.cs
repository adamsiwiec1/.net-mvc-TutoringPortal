using Fall2020AppGroup12.Controllers;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fall2020TestGroup12.ForumTest.Complex
{
    public class ComplexSearchTest
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


        public ComplexSearchTest()
        {
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            mockResponseRepo = new Mock<IResponseRepo>();
            mockCommentRepo = new Mock<ICommentRepo>();
            departmentController = new DepartmentController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            courseController = new CourseController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            responseController = new ResponseController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            commentController = new CommentController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);

        }



        [Fact]
        public void ShouldSearchForDiscussionsByCourse()
        {
            // Arange
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            List<Course> mockCourses = CreateMockCourseData();
            List<Discussion> mockDiscussions = CreateMockDiscussionData();
            mockDiscussionRepo.Setup(m => m.ListAllDiscussions()).Returns(mockDiscussions);  //Logic is in the controller
            mockCourseRepo.Setup(m => m.ListAllCourses()).Returns(mockCourses);
            discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);
            int expectedNumberOfDiscussionsInList = 3;

            // Act

            // DDL for Courses
            string courseID = "101";
            // Bring in View Model
            SearchForDiscussionsInCourseViewModel viewmodel = new SearchForDiscussionsInCourseViewModel();
            viewmodel.CourseID = courseID;
            viewmodel.UserFirstVisit = "No";


            ViewResult result = discussionController.SearchForDiscussionsByCourse(viewmodel) as ViewResult;
            SearchForDiscussionsInCourseViewModel resultModel = result.Model as SearchForDiscussionsInCourseViewModel;
            int actualNumbeOfDiscussionsInList = resultModel.ResultList.Count;

            // Assert - Compare Expected vs Actual. Did it work?
            Assert.Equal(expectedNumberOfDiscussionsInList, actualNumbeOfDiscussionsInList);

        }


        [Fact]
        public void ShouldSearchForDiscussionsByDepartmentUserInput()
        {
            // 1. Arange
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();

            List<Department> mockDepartments = CreateMockDepartmentData();
            List<Course> mockCourses = CreateMockCourseData();
            List<Discussion> mockDiscussions = CreateMockDiscussionData();

            mockDepartmentRepo.Setup(m => m.ListAllDepartments()).Returns(mockDepartments);
            mockCourseRepo.Setup(m => m.ListAllCourses()).Returns(mockCourses);
            mockDiscussionRepo.Setup(m => m.ListAllDiscussions()).Returns(mockDiscussions);

            int expectedNumberOfDiscussionsInList = 5;

            DiscussionController discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object);

            // DDL for Courses
            string deptid = "1";

            // Bring in View Model
            SearchForDiscussionsInDepartmentViewModel viewmodel = new SearchForDiscussionsInDepartmentViewModel();
            viewmodel.DepartmentID = deptid;
            viewmodel.UserFirstVisit = "No";

            // 2. Act
            ViewResult result = discussionController.SearchDiscussionsByDepartmentUserInput(viewmodel) as ViewResult;
            SearchForDiscussionsInDepartmentViewModel resultModel = result.Model as SearchForDiscussionsInDepartmentViewModel;
            int actualNumbeOfDiscussionsInList = resultModel.ResultList.Count;


            // 3. Assert - Compare Expected vs Actual. Did it work?
            Assert.Equal(expectedNumberOfDiscussionsInList, actualNumbeOfDiscussionsInList);

        }


        [Fact]
        public void ShouldSearchForDetailedDiscussionsByDepartmentUserInput()
        {
            // 1. Arange
            mockDepartmentRepo = new Mock<IDepartmentRepo>();
            mockCourseRepo = new Mock<ICourseRepo>();
            mockDiscussionRepo = new Mock<IDiscussionRepo>();
            mockResponseRepo = new Mock<IResponseRepo>();
            mockCommentRepo = new Mock<ICommentRepo>();

            List<Department> mockDepartments = CreateMockDepartmentData();
            List<Course> mockCourses = CreateMockCourseData();
            List<Discussion> mockDiscussions = CreateMockDiscussionData();
            List<Response> mockResponses = ListAllMockResponses();
            List<Comment> mockComments = ListAllMockComments();

            mockDepartmentRepo.Setup(m => m.ListAllDepartments()).Returns(mockDepartments);
            mockCourseRepo.Setup(m => m.ListAllCourses()).Returns(mockCourses);
            mockDiscussionRepo.Setup(m => m.ListAllDiscussions()).Returns(mockDiscussions);  //Logic is in the controller
            mockResponseRepo.Setup(m => m.ListAllResponses()).Returns(mockResponses);
            mockCommentRepo.Setup(m => m.ListAllComments()).Returns(mockComments);

            int expectedNumberOfDiscussionsInList = 6;

            DiscussionController discussionController = new DiscussionController(mockDepartmentRepo.Object, mockCourseRepo.Object, mockDiscussionRepo.Object, mockResponseRepo.Object, mockCommentRepo.Object);

            // DDL for Courses
            string deptId = "3";

            // Bring in View Model
            SearchForDetailedDiscussionsInDepartmentViewModel viewmodel = new SearchForDetailedDiscussionsInDepartmentViewModel();
            viewmodel.DepartmentID = deptId;
            viewmodel.UserFirstVisit = "No";

            // 2. Act
            ViewResult result = discussionController.SearchDetailedDiscussionsByDepartmentUserInput(viewmodel) as ViewResult;
            //SearchForDetailedDiscussionsInDepartmentViewModel resultModel = result.Model as SearchForDetailedDiscussionsInDepartmentViewModel;
            int actualNumbeOfDiscussionsInList = viewmodel.DiscussionResultList.Count;
            // 3. Assert - Compare Expected vs Actual. Did it work?
            Assert.Equal(expectedNumberOfDiscussionsInList, actualNumbeOfDiscussionsInList);

            foreach (Discussion discussion in viewmodel.DiscussionResultList) //Need loop to get responses from each discussion
            {
                int actualNumberOfResponsesInList = 0;

                if (discussion.ResponsesInDiscussion.Count != 0)
                {
                    foreach (Response resp in discussion.ResponsesInDiscussion)
                    {
                        if (resp.DiscussionID == discussion.DiscussionID)
                        {
                            actualNumberOfResponsesInList++;
                        }

                        int actualNumberOfCommentsInResponse = 0;

                        if (resp.CommentsInResponse.Count != 0)
                        {
                            foreach (Comment comment in resp.CommentsInResponse)
                            {
                                if (comment.ResponseID == resp.ResponseID)
                                {
                                    actualNumberOfCommentsInResponse++;
                                }

                            }
                            int expectedNumberOfCommentsInResponse = resp.CommentsInResponse.Count;
                            Assert.Equal(expectedNumberOfCommentsInResponse, actualNumberOfCommentsInResponse);
                        }
                    }
                    int expectedNumberOfResponsesInList = discussion.ResponsesInDiscussion.Count;
                    Assert.Equal(expectedNumberOfResponsesInList, actualNumberOfResponsesInList);
                }

            }


            //foreach(Response resp in resultModel.ResponseResultList)  
            //{


            //}
        }


        // Create bit complex Forum (mainly Discussion) data to peform tests

        public List<Department> CreateMockDepartmentData()
        {
            List<Department> mockDepartments = new List<Department>();

            Department department = new Department("Department 1", "Department Description");
            department.DepartmentID = 1;
            mockDepartments.Add(department);

            department = new Department("Department 2", "Department Description");
            department.DepartmentID = 2;
            mockDepartments.Add(department);

            department = new Department("Department 3", "Department Description");
            department.DepartmentID = 3;
            mockDepartments.Add(department);

            department = new Department("Department 4", "Department Description");
            department.DepartmentID = 4;
            mockDepartments.Add(department);

            return mockDepartments;
        }

        public List<Course> CreateMockCourseData()
        {
            List<Course> mockCourses = new List<Course>();
            int deptId = 1;

            Course course = new Course("TEST110", "Course in department one", deptId);
            course.CourseID = 101;
            mockCourses.Add(course);

            course = new Course("TEST210", "Course in department one", deptId);
            course.CourseID = 102;
            mockCourses.Add(course);

            course = new Course("TEST310", "Course in department one", deptId);
            course.CourseID = 103;
            mockCourses.Add(course);

            course = new Course("TEST410", "Course in department one", deptId);
            course.CourseID = 104;
            mockCourses.Add(course);

            deptId = 2;

            course = new Course("TEST120", "Course in department two", deptId);
            course.CourseID = 105;
            mockCourses.Add(course);

            course = new Course("TEST220", "Course in department two", deptId);
            course.CourseID = 106;
            mockCourses.Add(course);

            course = new Course("TEST320", "Course in department two", deptId);
            course.CourseID = 107;
            mockCourses.Add(course);

            course = new Course("TEST320", "Course in department two", deptId);
            course.CourseID = 108;
            mockCourses.Add(course);

            deptId = 3;

            course = new Course("9TEST130", "Course in department three", deptId);
            course.CourseID = 109;
            mockCourses.Add(course);

            course = new Course("TEST230", "Course in department three", deptId);
            course.CourseID = 110;
            mockCourses.Add(course);

            course = new Course("TEST330", "Course in department three", deptId);
            course.CourseID = 111;
            mockCourses.Add(course);

            deptId = 4;

            course = new Course("TEST140", "Course in department four", deptId);
            course.CourseID = 112;
            mockCourses.Add(course);

            course = new Course("TEST144", "Course in department four", deptId);
            course.CourseID = 113;
            mockCourses.Add(course);

            course = new Course("TEST240", "Course in department four", deptId);
            course.CourseID = 114;
            mockCourses.Add(course);

            course = new Course("TEST340", "Course in department four", deptId);
            course.CourseID = 115;
            mockCourses.Add(course);

            course = new Course("TEST440", "Course in department four", deptId);
            course.CourseID = 116;
            mockCourses.Add(course);

            return mockCourses;

        }



        public List<Discussion> CreateMockDiscussionData()
        {
            List<Discussion> mockDiscussions = new List<Discussion>();

            //Dept 1 - Course 1
            Discussion discussion = new Discussion("Discussion Title", "Dept #1 Course #1 Discussion #1 Description", DateTime.Now, 101, "10325");
            discussion.DiscussionID = 201;
            //Dept 1 - Course 1 - Discussion 1 Responses
            Response response = new Response("Response Title", "Discussion #1 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 301;
            //Dept 1 - Course 1 - Discussion 1 Comments
            Comment comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #4 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #1 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 302;
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #1 Response #3", discussion.DiscussionID, "001");
            response.ResponseID = 303;
            comment = new Comment("Comment #1 Response #3", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #1 Course #1 Discussion #2 Description", DateTime.Now, 101, "10325");
            discussion.DiscussionID = 202;
            //Dept 1 - Course 1 - Discussion 2 Responses
            response = new Response("Response Title", "Discussion #2 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 304;
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #2 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 305;
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #1 Course #1 Discussion #3 Description", DateTime.Now, 101, "10325");
            discussion.DiscussionID = 203;
            //Dept 1 - Course 1 - Discussion 3 Responses
            response = new Response("Response Title", "Discussion #3 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 306;
            comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #4 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #5 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #6 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #7 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);
            //Dept 1 - Course 2
            discussion = new Discussion("Discussion Title", "Dept #1 Course #2 Discussion #1 Description", DateTime.Now, 102, "34567");
            discussion.DiscussionID = 204;
            mockDiscussions.Add(discussion);
            //Dept 1 - Course 3
            discussion = new Discussion("Discussion Title", "Dept #1 Course #2 Discussion #1 Description", DateTime.Now, 103, "10327");
            discussion.DiscussionID = 205;
            mockDiscussions.Add(discussion);

            //Dept 2 - Course 1
            discussion = new Discussion("Discussion Title", "Dept #2 Course #1 Discussion #1 Description", DateTime.Now, 105, "10327");
            discussion.DiscussionID = 206;
            //Dept 2 - Course 1 - Discussion 3 Responses
            response = new Response("Response Title", "Discussion #6 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 307;
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #6 Response #2", discussion.DiscussionID, "001");
            comment = new Comment("Comment #1 Response #2", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #2", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            response.ResponseID = 308;
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #6 Response #3", discussion.DiscussionID, "001");
            comment = new Comment("Comment #1 Response #3", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            response.ResponseID = 309;
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #6 Response #4", discussion.DiscussionID, "001");
            response.ResponseID = 310;
            comment = new Comment("Comment #1 Response #4", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #4", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #4", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #4 Response #4", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #5 Response #4", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #6 Response #5", discussion.DiscussionID, "001");
            response.ResponseID = 311;
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            //Dept 2 - Course 2
            discussion = new Discussion("Discussion Title", "Dept #2 Course #4 Discussion #1 Description", DateTime.Now, 108, "10327");
            discussion.DiscussionID = 207;
            mockDiscussions.Add(discussion);

            //Dept 3 - Course 1
            discussion = new Discussion("Discussion Title", "Dept #3 Course #1 Discussion #1 Description", DateTime.Now, 109, "10327");
            discussion.DiscussionID = 208;
            //Dept 3 - Course 1 - Discussion 1 Responses
            response = new Response("Response Title", "Discussion #8 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 312;
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #3 Course #1 Discussion #2 Description", DateTime.Now, 109, "10327");
            discussion.DiscussionID = 209;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #3 Course #1 Discussion #3 Description", DateTime.Now, 109, "10327");
            discussion.DiscussionID = 210;
            //Dept 3 - Course 1 - Discussion 3 Responses
            response = new Response("Response Title", "Discussion #10 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 313;
            comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);

            response = new Response("Response Title", "Discussion #10 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 314;
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #3 Course #1 Discussion #4 Description", DateTime.Now, 109, "10327");
            discussion.DiscussionID = 211;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #3 Course #1 Discussion #5 Description", DateTime.Now, 109, "10327");
            discussion.DiscussionID = 212;
            mockDiscussions.Add(discussion);

            //Dept 3 - Course 2
            discussion = new Discussion("Discussion Title", "Dept #3 Course #2 Discussion #5 Description", DateTime.Now, 110, "10327");
            discussion.DiscussionID = 213;
            //Dept 3 - Course 2 - Discussion 6 Responses
            response = new Response("Response Title", "Discussion #13 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 315;
            discussion.ResponsesInDiscussion.Add(response);
            mockDiscussions.Add(discussion);

            //Dept 4 - Course 1
            discussion = new Discussion("Discussion Title", "Dept #4 Course #1 Discussion #2 Description", DateTime.Now, 112, "10327");
            discussion.DiscussionID = 214;
            //Dept 4 - Course 1 - Discussion 3 Responses
            response = new Response("Response Title", "Discussion #14 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 316;
            comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #4 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #14 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 317;
            discussion.ResponsesInDiscussion.Add(response);

            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #1 Discussion #2 Description", DateTime.Now, 112, "10327");
            discussion.DiscussionID = 215;
            //Dept 4 - Course 1 - Discussion 2 Responses
            response = new Response("Response Title", "Discussion #15 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 318;
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #15 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 319;
            discussion.ResponsesInDiscussion.Add(response);


            mockDiscussions.Add(discussion);

            //Dept 4 - Course 2
            discussion = new Discussion("Discussion Title", "Dept #4 Course #2 Discussion #1 Description", DateTime.Now, 113, "10327");
            discussion.DiscussionID = 216;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #2 Discussion #2 Description", DateTime.Now, 113, "10327");
            discussion.DiscussionID = 217;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #2 Discussion #3 Description", DateTime.Now, 113, "10327");
            discussion.DiscussionID = 218;
            mockDiscussions.Add(discussion);

            //Dept 4 - Course 3
            discussion = new Discussion("Discussion Title", "Dept #4 Course #5 Discussion #1 Description", DateTime.Now, 116, "10327");
            discussion.DiscussionID = 219;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #5 Discussion #2 Description", DateTime.Now, 116, "10327");
            discussion.DiscussionID = 220;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #5 Discussion #3 Description", DateTime.Now, 116, "10327");
            discussion.DiscussionID = 221;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #5 Discussion #4 Description", DateTime.Now, 116, "10327");
            discussion.DiscussionID = 222;
            mockDiscussions.Add(discussion);

            discussion = new Discussion("Discussion Title", "Dept #4 Course #5 Discussion #5 Description", DateTime.Now, 116, "10327");
            discussion.DiscussionID = 223;
            //Dept 4 - Course 3 - Discussion 8 Responses
            response = new Response("Response Title", "Discussion #23 Response #1", discussion.DiscussionID, "001");
            response.ResponseID = 320;
            comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #23 Response #2", discussion.DiscussionID, "001");
            response.ResponseID = 321;
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #23 Response #3", discussion.DiscussionID, "001");
            response.ResponseID = 322;
            discussion.ResponsesInDiscussion.Add(response);
            comment = new Comment("Comment #1 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #2 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #3 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #4 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            comment = new Comment("Comment #5 Response #1", response.ResponseID, "001");
            response.CommentsInResponse.Add(comment);
            response = new Response("Response Title", "Discussion #23 Response #4", discussion.DiscussionID, "001");
            response.ResponseID = 323;
            discussion.ResponsesInDiscussion.Add(response);
            response = new Response("Response Title", "Discussion #23 Response #5", discussion.DiscussionID, "001");
            response.ResponseID = 324;
            discussion.ResponsesInDiscussion.Add(response);


            mockDiscussions.Add(discussion);


            return mockDiscussions;

        }







        // Helper methods 


        /* Created this method because I didn't want to write the same loop over n over to get the mock response list from mock Discussion list */
        public List<Response> ListAllMockResponses()
        {
            List<Discussion> mockDiscList = CreateMockDiscussionData();
            List<Response> mockRespList = new List<Response>();

            foreach (Discussion disc in mockDiscList)
            {
                if (disc.ResponsesInDiscussion.Count != 0)
                {
                    foreach (Response resp in disc.ResponsesInDiscussion)
                    {
                        mockRespList.Add(resp);
                    }
                }
            }
            return mockRespList;
        }

        /* I did the same for comments, mock data for both is created using OOP list connections in CreateMockDiscussionData*/

        public List<Comment> ListAllMockComments()
        {
            List<Response> mockRespList = ListAllMockResponses(); // I can just use the method I created above instead of coming from discussion
            List<Comment> mockCommentList = new List<Comment>();

            foreach (Response resp in mockRespList)
            {
                if (resp.CommentsInResponse.Count != 0)
                {
                    foreach (Comment comment in resp.CommentsInResponse)
                    {
                        mockCommentList.Add(comment);
                    }
                }
            }
            return mockCommentList;
        }

    }
}
