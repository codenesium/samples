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

                Task<List<EventRelatedDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<EventRelatedDocument>> GetEventId(string eventId);
                Task<List<EventRelatedDocument>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId);
        }
}

/*<Codenesium>
    <Hash>ac8319737cc4ebd7542e439fc3a2d2c9</Hash>
</Codenesium>*/