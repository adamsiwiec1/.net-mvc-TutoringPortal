using Fall2020AppGroup12.Models;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fall2020AppGroup12.Data;
using System.IO;
using Fall2020AppGroup12.Models.AppUserModel;

namespace Fall2020AppGroup12.Data
{
    public class DbInitializer
    {


        public static void Initialize(IServiceProvider services)
        {

            //#1 -- database service
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //#2 -- role service
            //startup.cs line 35 add --> .AddRoles<IdentityRole>()  (this is different from what we do next step, keep this)
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            //#3 -- user service 
            //startup.cs line 34 change --> to ApplicationUser from IdentityUser (not where we added it in the prior step, but one line above)
            //_LoginPartial.cshtml change --> line 2 & 3 to ApplicationUser from IdentityUser
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string studentRole = "Student";
            string tutorRole = "Tutor";
            string administratorRole = "Administrator";

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(studentRole);
                roleManager.CreateAsync(role).Wait();
                //role manager creates AND saves, unlike db/user manager

                role = new IdentityRole(tutorRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(administratorRole);
                roleManager.CreateAsync(role).Wait();
            }


            if (!database.Department.Any()) //Does the pet table have any data in it?
            {

                // All WVU Colleges

                Department department = new Department("John Chambers College of Business and Economics", "Whether we’re anticipating global shifts or local trends, pushing products or launching businesses, the bottom line is always top of mind. We’re driving the economy through creative solutions and boldly building the future of business.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("Benjamin M. Statler College of Engineering and Mineral Resources", "By developing more efficient systems and technology, we’re launching a cleaner, smarter kind of industrial revolution. We look at the big picture and consider every tiny detail, all to make new connections in science and apply them to human life.");
                database.Department.Add(department);
                database.SaveChanges();


                department = new Department("College of Creative Arts", "We’re the original pioneers — crafting one-of-a-kinds from nothing but our imaginations, raw materials and artistic skill.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("College of Education and Human Services", "A better future is yours to give. We ensure that our students gain professional experience through real-world opportunities. You will graduate ready to lead and inspire generations of great minds.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("College of Physical Activity and Sport Sciences", "Where science meets application, we’re creating a stronger, healthier world. By researching the discipline behind physical activity and sport, driving healthy sports participation and developing new ways to keep people active, we’re changing lives.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("Davis College of Agriculture, Natural Resources and Design", "This is where justice and ethics guide every argument, and real courtroom experience gets us practice-ready. We’re building on the foundation of a traditional law program and innovating new ways to address tomorrow’s local and global challenges.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("Eberly College of Arts and Sciences", "This is where justice and ethics guide every argument, and real courtroom experience gets us practice-ready. We’re building on the foundation of a traditional law program and innovating new ways to address tomorrow’s local and global challenges.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("Reed College of Media", "We are more than journalists and communicators — we are storytellers. We speak across every medium and connect with every audience. Whether it’s news, information, entertainment or promotion, we are the voice.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("School of Dentistry", "From the classroom to the clinic, WVU dental and dental hygiene students work in small groups and get extensive hands-on experience in patient care. Graduates can go directly into practice or begin exciting careers in oral health research.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("School of Medicine", "We exist at the forefront of modern medicine — advancing the scientific study of human life and bringing critical care to all who suffer. In our biggest cities, smallest towns and rural areas, we are the face of medicine.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("School of Nursing", "Born with a heart to care for others, we’re developing the knowledge and skills to care for dozens of people at once, all while advancing research that will improve care for all.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("School of Pharmacy", "Pharmacists are the most accessible healthcare professionals. With the patient care we provide and the medication therapies we manage, we’re caring for the people behind every prescription.");
                database.Department.Add(department);
                database.SaveChanges();

                department = new Department("School of Public Health", "Our students are tackling the critical health issues facing communities in West Virginia and beyond.");
                database.Department.Add(department);
                database.SaveChanges();

            }


            if (!database.Major.Any())
            {
                Major major = new Major("Accounting", "Explore the business side of organizational activities with advanced courses in accounting and financial reporting, as well as an integrated overview of the economic pursuits of a business entity.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Economics", "Identify the costs, benefits and consequences of a decision and be prepared to go into the world studying issues that affect the market, such as criminal behavior, poverty, law, environmental control, population and political behavior.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Entrepreneurship and Innovation", "Manage growth in existing organizations, including small and medium-sized enterprises, large corporations, family business and socially-orientated ventures by working closely with WVU’s Encova Center.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Finance", "Study the creation and management of wealth for a position in either financial or non-financial enterprises. Experience real financial markets and investment portfolio management from national institutions, such as the New York Stock Exchange and the Nasdaq.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("General Business", "Learn the basic fundamentals to gain an overall understanding of business and how organizations – large and small – operate, so that you can enter corporate management training programs or apply your skills to a variety of industries.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Global Supply Chain Management", "Recognize the systemic and global nature of supply chain operations, so you can identify interdependencies critical to effectively manage and improve performance, strategically integrate processes and technology, and make ethical supply chain decisions.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Hospitality and Tourism Management", "Receive hands-on experience so that you are ready to lead a customer-focused team. You will acquire the skills you need for a career in the hotel, restaurant, event planning, theme park or management field.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Management", "Gain important business principles, business ethics, leadership and employee management skills needed to take on a cross-functional managerial position within any industry or organization of any size.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Management Information Systems", "Explore cutting-edge technologies with sound business management practices. From systems analysis and design to networking and database management, gain the tools you need to analyze business problems, as well as design, build and maintain computer applications for solving problems.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Marketing", "Gain a strong understanding of marketing elements used by firms and in-house teams to satisfy customer wants and needs. You will participate in real-world activities so you can learn the tools most commonly used to help a team promote a product or service.", 1);
                database.Major.Add(major);
                database.SaveChanges();

                major = new Major("Organizational Leadership", "With the opportunity to gain national and global experiences, you will learn the effective methods to handle conflict and negotiations, and to foster and lead organizational change, to be ready for a career in nonprofit, public or private leadership.", 1);
                database.Major.Add(major);
                database.SaveChanges();
            }

            if (!database.ApplicationUser.Any())
            {
                int majorID = 1;
                Student student = new Student("Test", "Student1", "1 Student Address", "3040000001", "TestStudent1@test.com", "TestStudent1", majorID, "TestBio1", "May 2021");
                student.EmailConfirmed = true;
                userManager.CreateAsync(student).Wait();
                userManager.AddToRoleAsync(student, studentRole).Wait();

                //ALL async methods need to have a Wait(); attached
                //regular methods execute immediatley, async need some time

                student = new Student("Test", "Student2", "2 Student Address", "3040000001", "TestStudent2@test.com", "TestStudent2", majorID, "TestBio2", "May 2021");
                student.EmailConfirmed = true;
                userManager.CreateAsync(student).Wait();
                userManager.AddToRoleAsync(student, studentRole).Wait();

                Tutor tutor = new Tutor("Test", "Tutor1", "1 Tutor Address", "3040000003", "TestTutor1@test.com", "TestTutor1", majorID, "TestBio", "Decemeber 2020", 1);
                tutor.EmailConfirmed = true;
                userManager.CreateAsync(tutor).Wait();
                userManager.AddToRoleAsync(tutor, tutorRole).Wait();

                tutor = new Tutor("Test", "Tutor2", "2 Tutor Address", "3040000004", "TestTutor2@test.com", "TestTutor1", majorID, "TestBio", "Decemeber 2020", 5);
                tutor.EmailConfirmed = true;
                userManager.CreateAsync(tutor).Wait();
                userManager.AddToRoleAsync(tutor, tutorRole).Wait();

                tutor = new Tutor("Smart", "Tutor", "3 Tutor Address", "3040000005", "SmartTutor@test.com", "TestTutor3", majorID, "TestBio", "Decemeber 2021", 5);
                tutor.EmailConfirmed = true;
                userManager.CreateAsync(tutor).Wait();
                userManager.AddToRoleAsync(tutor, tutorRole).Wait();

                ApplicationUser applicationUser = new ApplicationUser("Test", "Administrator1", "Administartor1 Address", "3040000005", "TestAdministrator1@test.com", "TestAdministrator1", 1);
                applicationUser.EmailConfirmed = true;
                userManager.CreateAsync(applicationUser).Wait();
                userManager.AddToRoleAsync(applicationUser, administratorRole).Wait();

            }


            // FULL WVU COURSE LIST - 995 courses
            if (!database.Course.Any())
            {
                HelperMethods hm = new HelperMethods();

                List<string> courseList = hm.GetAllWVUCourses();

                foreach(string x in courseList)
                {
                    //Format errors - Only Used for WVU Tech Campus
                    //string[] y = x.Split("�", ' ');
                    //y[1] = y[1].Substring(0, 3);
                    //string course = y[0] + " " + y[1];

                    //Add to Db
                    
                    Course newCourse = new Course(x, "Test Description", 1);
                    database.Course.Add(newCourse);
                    database.SaveChanges();
                }
            }



            if (!database.Discussion.Any())
            {

                DateTime dateCreated = new DateTime(2020, 10, 05);

                ApplicationUser applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();
                string userID = applicationuser.Id;
                int courseID = 1;

                Discussion discussion = new Discussion("Building a MVC Web Application.", "Can someone explain the difference between Model, View, and Controller to me?", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("How do I make a foreach loop in C#?", "Can someone please help me iterate through my list of objects and print them using a for each loop?", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 6;

                discussion = new Discussion("Accounting Discussion 1", "Accounting Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Accounting Discussion 2", " Accounting Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Accounting Discussion 3", "Accounting Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestTutor2@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 10;

                discussion = new Discussion("Finance Discussion 1", "Finance Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Finance Discussion 2", " Finance Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Finance Discussion 3", "Finance Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 12;

                discussion = new Discussion("Economics Discussion 3", "Economics Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Economics Discussion 2", " Economics Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Economics Discussion 3", "Economics Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 16;

                discussion = new Discussion("Hospitality Discussion 1", "Hospitality Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Hospitality Discussion 2", " Hospitality Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Hospitality Discussion 3", "Hospitality Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 17;

                discussion = new Discussion("DataAnalytics Discussion 1", "DataAnalytics Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("DataAnalytics Discussion 2", " DataAnalytics Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("DataAnalytics Discussion 3", "DataAnalytics Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                applicationuser = database.ApplicationUser.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();
                userID = applicationuser.Id;
                courseID = 18;

                discussion = new Discussion("Cybersecurity Discussion 1", "Cybersecurity Discussion Description 1", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Cybersecurity Discussion 2", " Cybersecurity Discussion Description 2", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

                discussion = new Discussion("Cybersecurity Discussion 3", "Cybersecurity Discussion Description 3", dateCreated, courseID, userID);
                database.Discussion.Add(discussion);
                database.SaveChanges();

            }

            if (!database.Response.Any())
            {
                ApplicationUser applicationUser = database.ApplicationUser.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();

                Response response = new Response("You must first understand the Model-View-Controller architecture.", "There are three componenets to a MVC project. The Model, where you define your classes or models. The View, where you will store all your HTML files, and the controller where you will keep your methods to manipulate these objects and display them to their corresponding view. ", 1, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("For each loop basics", "Whatever list you want to iterate through, you must be using a corresponding object to iterate through it. If you are iterating through a list of integers, then you will write 'foreach(int num in myList)'. However, if you are iterating through a complex list of objects such as students, you would write foreach(Student stu in studentList). Hope that helps! ", 2, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();
                
                response = new Response("MIST 450 Foreach loop Discussion Response Title", "This is a response to an MIST 450 Discussion.", 2, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                applicationUser = database.ApplicationUser.Where(a => a.Email == "TestTutor1@test.com").FirstOrDefault();

                response = new Response("Accounting Response Title", "This is a response to an accounting discussion.", 3, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();


                response = new Response("Accounting Response Title Two", "This is the second response in an accounting discussion.", 3, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Accounting Response Title", "This is a response to an accounting discussion.", 4, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                applicationUser = database.ApplicationUser.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();

                response = new Response("Finance Response Title", "This is a response to a finance discussion.", 7, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();


                response = new Response("Finance Response Title Two", "This is the second response in a finance discussion.", 7, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Finance Response Title Three", "This is the third response to a finance discussion.", 7, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Economics Response Title", "This is a response to a finance discussion.", 9, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                applicationUser = database.ApplicationUser.Where(a => a.Email == "TestStudent1@test.com").FirstOrDefault();

                response = new Response("Economics Response Title Two", "This is the second response in a finance discussion.", 9, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Economics Response Title Three", "This is the third response to a finance discussion.", 9, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Hospitality Response Title", "This is a response to a hospitality discussion.", 12, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Hospitality Response Title", "This is a response to a hospitality discussion.", 13, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Hospitality Response Title", "This is a response to a hospitality discussion.", 14, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                applicationUser = database.ApplicationUser.Where(a => a.Email == "TestStudent2@test.com").FirstOrDefault();

                response = new Response("DataAnalytics Response Title", "This is a response to a datanaytics discussion.", 15, applicationUser.Id);
                database.SaveChanges();

                response = new Response("DataAnalytics Response Title Two", "This is a response to a hospitality discussion.", 15, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("DataAnalytics Response Title Three", "This is a response to a hospitality discussion.", 15, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("DataAnalytics Response Title Four", "This is a response to a hospitality discussion.", 15, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("DataAnalytics Response Title Five", "This is a response to a hospitality discussion.", 15, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Cybersecurity Response Title", "This is a response to a cybersec discussion.", 18, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Cybersecurity Response Title Two", "This is the second response to a cybersec discussion.", 18, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();

                response = new Response("Cybersecurity Response Title", "This is a response to a cybersec discussion.", 20, applicationUser.Id);
                database.Response.Add(response);
                database.SaveChanges();


            }


            if (!database.Comment.Any())
            {
                ApplicationUser applicationUser = database.ApplicationUser.Where(a => a.Email == "TestTutor2@test.com").FirstOrDefault();
                Comment comment = new Comment("Test Comment body 1", 1, applicationUser.Id);
                database.Comment.Add(comment);
                database.SaveChanges();

                comment = new Comment("Test Comment body 2", 2, applicationUser.Id);
                database.Comment.Add(comment);
                database.SaveChanges();

                applicationUser = database.ApplicationUser.Where(a => a.Email == "TestTutor1@test.com").FirstOrDefault();
                comment = new Comment("Test Comment body 3", 3, applicationUser.Id);
                database.Comment.Add(comment);
                database.SaveChanges();
            }

            if (!database.TutorCourse.Any())
            {
                ApplicationUser applicationuser = database.ApplicationUser.Where(a => a.Email == "TestTutor1@test.com").FirstOrDefault();

                string userID = applicationuser.Id;

                TutorCourse course = new TutorCourse(userID, 2);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                course = new TutorCourse(userID, 1);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                ApplicationUser applicationuser2 = database.ApplicationUser.Where(a => a.Email == "TestTutor2@test.com").FirstOrDefault();

                userID = applicationuser.Id;

                course = new TutorCourse(userID, 2);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                course = new TutorCourse(userID, 1);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                userID = applicationuser2.Id;

                course = new TutorCourse(userID, 3);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                course = new TutorCourse(userID, 6);
                database.TutorCourse.Add(course);
                database.SaveChanges();

                HelperMethods hm = new HelperMethods();

                Tutor tutor = database.Tutor.Where(a => a.Email == "SmartTutor@test.com").FirstOrDefault();
                userID = tutor.Id;

                List<string> courseList = hm.GetAllWVUCourses();

                foreach(string x in courseList)
                {
                    Course eachCourse = database.Course.Where(c => c.CourseCode == x).FirstOrDefault();  // This takes forever bcuz it has to do Where statement, then Insert

                    TutorCourse tutorCourse = new TutorCourse(userID, eachCourse.CourseID);
                    database.TutorCourse.Add(tutorCourse);
                    database.SaveChanges();
                }

            }

        } //end of Method

    } //end of DbInitializer

} //end of namespace
