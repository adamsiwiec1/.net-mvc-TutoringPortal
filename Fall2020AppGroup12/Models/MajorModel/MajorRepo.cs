using Fall2020AppGroup12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.MajorModel
{
    public class MajorRepo : IMajorRepo
    {
        private ApplicationDbContext database;

        public MajorRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add

        public void AddMajor(Major major)
        {
            database.Major.Add(major);
            database.SaveChanges();
        }

        // Edit
        public void EditMajor(Major major)
        {
            database.Major.Update(major);
            database.SaveChanges();
        }

        // Delete 

        public void DeleteMajor(Major major)
        {
            database.Major.Remove(major);
            database.SaveChanges();
        }
        // List All

        public List<Major> ListAllMajors()
        {
            List<Major> majors = database.Major.ToList();
            return majors;
        }

        public Major FindMajor(int? majorID)
        {
            return database.Major.Find(majorID);
        }
    }
}
