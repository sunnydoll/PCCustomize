using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCustomize.Models
{
    public interface IMessage
    {
        IQueryable<Topic> GetTopics();
        IQueryable<Topic> GetTopics(int computerId);
        IQueryable<Topic> GetTopicsIncludingReplies(int computerId);
        IQueryable<Reply> GetRepliesByTopics(int topicId);

        bool Save();
        bool AddTopic(Topic newTopic);
        bool AddReply(Reply newReply);
    }
}
