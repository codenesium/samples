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

                Task<List<Event>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Event>> GetAutoId(long autoId);
                Task<List<Event>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTime occurred, string category, long autoId);
                Task<List<Event>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTime occurred, string tenantId);
                Task<List<Event>> GetIdOccurred(string id, DateTime occurred);
        }
}

/*<Codenesium>
    <Hash>9323a8e91f4f77ebefb60b3f52409db6</Hash>
</Codenesium>*/