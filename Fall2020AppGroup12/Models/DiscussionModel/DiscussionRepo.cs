using Fall2020AppGroup12.Data;
using Fall2020AppGroup12.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DiscussionModel
{
    public class DiscussionRepo : IDiscussionRepo
    {

        private ApplicationDbContext database;

        public DiscussionRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }


        // Add 
        public void AddDiscussion(Discussion discussion)
        {
            database.Discussion.Add(discussion);
            database.SaveChanges();
        }

        // Edit
        public void EditDiscussion(Discussion discussion)
        {
            database.Discussion.Update(discussion);
            database.SaveChanges();
        }

        // Delete
        public void DeleteDiscussion(Discussion discussion)
        {
            database.Discussion.Remove(discussion);
            database.SaveChanges();
        }

        // List All
        public List<Discussion> ListAllDiscussions()
        {
            List<Discussion> discussions = database.Discussion.ToList();
            return discussions;
        }

        // Search
        public Discussion FindDiscussion(int? discussionID)
        {
            Discussion discussion = database.Discussion.Find(discussionID);

            return discussion;
        }
    }
}
