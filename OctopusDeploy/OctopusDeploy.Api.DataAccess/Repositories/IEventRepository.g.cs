using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IEventRepository
        {
                Task<Event> Create(Event item);

                Task Update(Event item);

                Task Delete(string id);

                Task<Event> Get(string id);

                Task<List<Event>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Event>> GetAutoId(long autoId);
                Task<List<Event>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId);
                Task<List<Event>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId);
                Task<List<Event>> GetIdOccurred(string id, DateTimeOffset occurred);

                Task<List<EventRelatedDocument>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d6302b7b35ad4197ad79a9f7c818be63</Hash>
</Codenesium>*/