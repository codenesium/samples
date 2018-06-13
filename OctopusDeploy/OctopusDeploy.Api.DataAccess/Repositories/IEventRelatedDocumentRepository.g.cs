using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IEventRelatedDocumentRepository
        {
                Task<EventRelatedDocument> Create(EventRelatedDocument item);

                Task Update(EventRelatedDocument item);

                Task Delete(int id);

                Task<EventRelatedDocument> Get(int id);

                Task<List<EventRelatedDocument>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<EventRelatedDocument>> GetEventId(string eventId);
                Task<List<EventRelatedDocument>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId);
        }
}

/*<Codenesium>
    <Hash>f40421d75435f4f78a7c5d03a30bc2df</Hash>
</Codenesium>*/