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
    public class TopicsController : ApiController
    {
        private IMessage _msg;

        public TopicsController(IMessage msg)
        {
            _msg = msg;
        }

        public IEnumerable<Topic> Get()
        {
            var topics = _msg.GetTopics().OrderBy(r => r.Created).Take(20).ToList();
            return topics;
        }

        public IEnumerable<Topic> Get(int computerid, bool includeReplies = false)
        {
            IQueryable<Topic> results;
            if (includeReplies == true)
            {
                results = _msg.GetTopicsIncludingReplies(computerid);
            }
            else
            {
                results = _msg.GetTopics(computerid);
            }
            var topics = results.OrderBy(r => r.Created).Take(20).ToList();
            return topics;
        }

        public HttpResponseMessage Post(int computerid, [FromBody]Topic newTopic)
        {
            if (newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            newTopic.ComputerId = computerid;
            newTopic.UserName = User.Identity.Name;

            if (_msg.AddTopic(newTopic) && _msg.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newTopic);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
