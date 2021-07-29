using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Fall2020AppGroup12.Models.TutorModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fall2020TestGroup12
{
    public class MockData
    {

        private Mock<IMajorRepo> iMajorRepo;
        private ICourseRepo iCourseRepo;

        //public MockData()
        //{
        //    iCourseRepo = new Mock<ICourseRepo>();
        //}


        // Forum Data

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

            Course course = new Course("TEST 100", "Course in department one", deptId);

            course.CourseID = 1;
            mockCourses.Add(course);

            course = new Course("TEST 200", "Course in department one", deptId);

            course.CourseID = 2;
            mockCourses.Add(course);

            course = new Course("TEST 300", "Course in department one", deptId);
            course.CourseID = 3;
            mockCourses.Add(course);

            return mockCourses;

        }

        public List<Discussion> CreateMockDiscussionData()
        {
            List<Discussion> mockDiscussions = new List<Discussion>();

            int courseID = 1;
            string appUserId = "2";
            Discussion discussion = new Discussion("Discussion Title 1", "Discussion Description", DateTime.Now, courseID, appUserId);
            mockDiscussions.Add(discussion);
            discussion = new Discussion("Discussion Title 2", "Discussion Description", DateTime.Now, courseID, appUserId);
            mockDiscussions.Add(discussion);
            discussion = new Discussion("Discussion Title 3", "Discussion Description", DateTime.Now, courseID, appUserId);
            mockDiscussions.Add(discussion);

            return mockDiscussions;

        }


        public List<Response> CreateMockResponseData()
        {
            List<Response> mockResponses = new List<Response>();

            int discussionId = 1;
            Response response = new Response("Response Title 1", "Discussion Response", discussionId, "001");
            mockResponses.Add(response);
            response = new Response("Response Title 2", "Discussion Response", discussionId, "001");
            mockResponses.Add(response);
            response = new Response("Response Title 3", "Discussion Response", discussionId, "001");
            mockResponses.Add(response);
            discussionId = 2;
            response = new Response("Response Title 4", "Discussion Response", discussionId, "001");
            mockResponses.Add(response);
            response = new Response("Response Title 5", "Discussion Response", discussionId, "001");
            mockResponses.Add(response);

            return mockResponses;
        }

        public List<Comment> CreateMockCommentData()
        {
            List<Comment> mockComments = new List<Comment>();

            int responseId = 1;
            Comment comment = new Comment("Comment #1 Response #1", responseId, "001");
            mockComments.Add(comment);
            comment = new Comment("Comment #2 Response #2", responseId, "001");
            mockComments.Add(comment);
            comment = new Comment("Comment #3 Response #3", responseId, "001");
            mockComments.Add(comment);
            responseId = 2;
            comment = new Comment("Comment #4 Response #1", responseId, "001");
            mockComments.Add(comment);
            comment = new Comment("Comment #5 Response #2", responseId, "001");
            mockComments.Add(comment);

            return mockComments;
        }

        // User Data


        public List<Student> CreateMockStudentData()
        {
            List<Student> mockStudents = new List<Student>();

            int majorID = 1;
            Student student = new Student("Test Fname", "Test Lname", "111 Student Street", "3041234567", "asdfg1111@email.com", "password", majorID, "I am a student - bio", "May 2022");
            mockStudents.Add(student);
            student = new Student("Test Fname", "Test Lname", "222 Student Street", "3040000000", "asdfg2222@email.com", "password", majorID, "I am a student - bio", "May 2023");
            mockStudents.Add(student);
            majorID = 2;
            student = new Student("Test Fname", "Test Lname", "333 Student Street", "3041111111", "asdfg3333@email.com", "password", majorID, "I am a student - bio", "May 2023");
            mockStudents.Add(student);
            majorID = 3;
            student = new Student("Test Fname", "Test Lname", "444 Student Street", "3042222222", "asdfg4444@email.com", "password", majorID, "I am a student - bio", "December 2022");
            mockStudents.Add(student);
            student = new Student("Test Fname", "Test Lname", "555 Student Street", "3043333333", "asdfg5555@email.com", "password", majorID, "I am a student - bio", "December 2023");
            mockStudents.Add(student);

            return mockStudents;
        }

        public List<Tutor> CreateMockTutorData()
        {
            List<Tutor> mockTutors = new List<Tutor>();
            iMajorRepo = new Mock<IMajorRepo>();


            int majorID = 1;
            Tutor tutor = new Tutor("Test Fname", "Test Lname", "111 Tutor Street", "3041234567", "asdfg1111@email.com", "password", majorID, "I tutor ppl - test bio", "May 2021", 1);
            Course course = new Course("TEST 100", "Course in department one", 1);
            course.CourseID = 1;
            tutor.QualifiedCourses.Add(course);
            tutor.Major = new Major("Management Information Systems", "MIS", 1);




            course = new Course("TEST 200", "Course in department one", 1);
            course.CourseID = 2;
            tutor.QualifiedCourses.Add(course);
            tutor.Major = new Major("Management Information Systems", "MIS", 1);
            course = new Course("TEST 300", "Course in department two", 2);
            course.CourseID = 3;
            tutor.QualifiedCourses.Add(course);
            tutor.Major = new Major("Management Information Systems", "MIS", 1);
            tutor.Id = "1";
            mockTutors.Add(tutor);
            majorID = 2;
            tutor = new Tutor("Test Fname", "Test Lname", "333 Tutor Street", "3041111111", "asdfg3333@email.com", "password", majorID, "I tutor ppl - test bio", "May 2021", 4);
            course = new Course("TEST 200", "Course in department one", 1);
            course.CourseID = 2;
            tutor.QualifiedCourses.Add(course);
            tutor.Major = new Major("Management Information Systems", "MIS", 1);
            course = new Course("TEST 300", "Course in department two", 2);
            course.CourseID = 3;
            tutor.QualifiedCourses.Add(course);
            tutor.Major = new Major("Management Information Systems", "MIS", 1);
            tutor.Id = "2";
            mockTutors.Add(tutor);

            return mockTutors;
        }


        public List<TutorCourse> CreateMockTutorCourseData()
        {

            List<TutorCourse> mockTutorCourses = new List<TutorCourse>();

            string tutorId = "1";
            int courseID = 1;
            TutorCourse tutorCourse = new TutorCourse(tutorId, courseID);
            mockTutorCourses.Add(tutorCourse);
            courseID = 2;
            tutorCourse = new TutorCourse(tutorId, courseID);
            mockTutorCourses.Add(tutorCourse);
            courseID = 3;
            tutorCourse = new TutorCourse(tutorId, courseID);
            mockTutorCourses.Add(tutorCourse);
            tutorId = "2";
            courseID = 4;
            tutorCourse = new TutorCourse(tutorId, courseID);
            mockTutorCourses.Add(tutorCourse);
            courseID = 5;
            tutorCourse = new TutorCourse(tutorId, courseID);
            mockTutorCourses.Add(tutorCourse);


            return mockTutorCourses;

        }

        public List<Major> CreateMockMajorData()
        {
            List<Major> mockMajors = new List<Major>();
            int departmentId = 1;
            Major major = new Major("Management Information Systems", "MIS", departmentId);
            major.MajorID = 1;
            major.TutorsInMajor = CreateMockTutorData();
            mockMajors.Add(major);
            major = new Major("Finance", "FIN", departmentId);
            major.MajorID = 2;
            major.TutorsInMajor = null;
            mockMajors.Add(major);
            major = new Major("Accounting", "ACCT", departmentId);
            major.MajorID = 3;
            major.TutorsInMajor = null;
            mockMajors.Add(major);
            departmentId = 200;
            major = new Major("Computer Engineering", "CE", departmentId);
            major.MajorID = 4;
            major.TutorsInMajor = CreateMockTutorData();
            mockMajors.Add(major);
            major = new Major("Computer Science", "CS", departmentId);
            major.MajorID = 5;
            major.TutorsInMajor = CreateMockTutorData();
            mockMajors.Add(major);


            return mockMajors;
        }



        // Ticket Data 


        public List<Ticket> CreateMockTicketData()
        {
            List<Ticket> mockTickets = new List<Ticket>();

            // Ticket Status:
            // 1. Open
            // 2. In Progress
            // 3. Closed

            // GetTicketStatus() method in Ticket class determines the status of our ticket based on the following factors:
            // Has a tutor been assigned?
            // Has the 'Closed' boolean been set to true?

            string studentUserId = "101";
            string tutorUserId = "201";
            Ticket ticket = new Ticket("Test Ticket", null, null, null, studentUserId, tutorUserId, "Open", null, null, false, 1, iCourseRepo);
            ticket.CourseCode = "TEST 101";
            ticket.TicketID = 1;




            mockTickets.Add(ticket);
            ticket = new Ticket("Test Ticket", null, null, null, studentUserId, null, "Open", null, null, false, 2, iCourseRepo);
            ticket.CourseCode = "TEST 101";
            ticket.TicketID = 2;
            mockTickets.Add(ticket);
            ticket = new Ticket("Test ticket", null, null, null, studentUserId, tutorUserId, "Open", null, null, false, 3, iCourseRepo);
            ticket.CourseCode = "TEST 101";
            ticket.TicketID = 3;
            mockTickets.Add(ticket);
            studentUserId = "102";
            tutorUserId = "102";
            ticket = new Ticket("Test Ticket", null, null, null, studentUserId, tutorUserId, "Open", null, null, true, 4, iCourseRepo);
            ticket.CourseCode = "TEST 101";
            ticket.TicketID = 4;
            mockTickets.Add(ticket);

            return mockTickets;
        }

    }
}
