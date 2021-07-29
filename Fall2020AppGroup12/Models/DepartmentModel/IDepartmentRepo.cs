using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DepartmentModel
{
    public interface IDepartmentRepo
    {

        List<Department> ListAllDepartments();

        void AddDepartment(Department department);
        void EditDepartment(Department department);
        void DeleteDepartment(Department department);
        Department FindDepartment(int? departmentID);

    }
}
