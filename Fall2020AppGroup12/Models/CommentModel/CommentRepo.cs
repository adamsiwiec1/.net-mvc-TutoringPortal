using Fall2020AppGroup12.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CommentModel
{
    public class CommentRepo : ICommentRepo
    {
        private ApplicationDbContext database;

        public CommentRepo(ApplicationDbContext dbContext) //ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        // Add
        public void AddComment(Comment comment)
        {
            database.Comment.Add(comment);
            database.SaveChanges();
        }

        // Edit
        public void EditComment(Comment comment)
        {
            database.Comment.Update(comment);
            database.SaveChanges();
        }

        // Delete
        public void DeleteComment(Comment comment)
        {
            database.Comment.Remove(comment);
            database.SaveChanges();
        }

        // List All
        public List<Comment> ListAllComments()
        {
            List<Comment> comments = database.Comment.ToList();
            return comments;
        }

        // Search
        public Comment FindComment(int? commentID)
        {
            Comment comment = database.Comment.Find(commentID);

            return comment;
        }
    }
}
