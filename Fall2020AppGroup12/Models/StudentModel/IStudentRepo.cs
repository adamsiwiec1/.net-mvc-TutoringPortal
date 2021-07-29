using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.StudentModel
{
    public interface IStudentRepo
    {
        string FindLoggedInStudent();

        List<Student> ListAllStudents();
        Student FindStudent(string studentId);
        string AddStudent(Student student);
    }
}
