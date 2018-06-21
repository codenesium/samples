using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IEventRelatedDocumentRepository
        {
                Task<EventRelatedDocument> Create(EventRelatedDocument item);

                Task Update(EventRelatedDocument item);

                Task Delete(int id);

                Task<EventRelatedDocument> Get(int id);

                Task<List<EventRelatedDocument>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<EventRelatedDocument>> GetEventId(string eventId);

                Task<List<EventRelatedDocument>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId);

                Task<Event> GetEvent(string eventId);
        }
}

/*<Codenesium>
    <Hash>7dd618ed62e48cb188aac84baf10a81f</Hash>
</Codenesium>*/