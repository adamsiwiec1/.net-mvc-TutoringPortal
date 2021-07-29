using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.CommentModel
{
    public interface ICommentRepo
    {
        List<Comment> ListAllComments();

        void AddComment(Comment comment);
        void DeleteComment(Comment comment);
        void EditComment(Comment comment);
        Comment FindComment(int? commentID);
    }
}
