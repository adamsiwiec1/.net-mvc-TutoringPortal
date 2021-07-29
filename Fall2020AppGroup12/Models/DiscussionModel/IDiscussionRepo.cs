using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.DiscussionModel
{
    public interface IDiscussionRepo
    {

        List<Discussion> ListAllDiscussions();
        void AddDiscussion(Discussion discussion);
        void EditDiscussion(Discussion discussion);
        Discussion FindDiscussion(int? discussionID);
        void DeleteDiscussion(Discussion discussion);
    }
}
