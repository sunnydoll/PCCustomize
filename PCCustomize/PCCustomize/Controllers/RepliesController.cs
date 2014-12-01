using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PCCustomize.Models;
using WebMatrix.WebData;

namespace PCCustomize.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessage _msg;

        public RepliesController(IMessage msg)
        {
            _msg = msg;
        }

        public IEnumerable<Reply> Get(int topicid)
        {
            return _msg.GetRepliesByTopics(topicid);
        }

        public HttpResponseMessage Post(int topicid, [FromBody]Reply newReply)
        {
            if (newReply.Created == default(DateTime))
            {
                newReply.Created = DateTime.UtcNow;
            }

            newReply.TopicId = topicid;
            newReply.UserName = User.Identity.Name;

            if (_msg.AddReply(newReply) && _msg.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newReply);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
