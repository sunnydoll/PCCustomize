using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCCustomize.Models
{
    public class MessageRepository : IMessage
    {
        CustomizeDB _db;

        public MessageRepository(CustomizeDB db)
        {
            _db = db;
        }

        public IQueryable<Topic> GetTopics()
        {
            return _db.Topics;
        }

        public IQueryable<Topic> GetTopics(int computerId)
        {
            return _db.Topics.Where(r => r.ComputerId == computerId);
        }

        public IQueryable<Reply> GetRepliesByTopics(int topicId)
        {
            return _db.Replies.Where(r => r.TopicId == topicId);
        }

        public bool Save()
        {
            try
            {
                return _db.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _db.Topics.Add(newTopic);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<Topic> GetTopicsIncludingReplies(int computerId)
        {
            return _db.Topics.Include("Replies").Where(r => r.ComputerId == computerId);
        }

        public bool AddReply(Reply newReply)
        {
            try
            {
                _db.Replies.Add(newReply);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}