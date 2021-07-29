using Fall2020AppGroup12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DepartmentModel
{
    public class DepartmentRepo : IDepartmentRepo
    {

        private ApplicationDbContext database;

        public DepartmentRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add 
        public void AddDepartment(Department department)
        {
            database.Department.Update(department);
            database.SaveChanges();
        }

        // Edit
        public void EditDepartment(Department department)
        {
            database.Department.Update(department);
            database.SaveChanges();
        }

        // Delete
        public void DeleteDepartment(Department department)
        {
            database.Department.Remove(department);
            database.SaveChanges();
        }

        // List All
        public List<Department> ListAllDepartments()
        {
            List<Department> allDepartments = database.Department.ToList();
            return allDepartments;
        }

        // Search
        public Department FindDepartment(int? departmentID)
        {
            return database.Department.Find(departmentID);
        }
    }
}
