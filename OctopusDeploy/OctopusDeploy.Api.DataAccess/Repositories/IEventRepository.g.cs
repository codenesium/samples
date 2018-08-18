using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IEventRepository
	{
		Task<Event> Create(Event item);

		Task Update(Event item);

		Task Delete(string id);

		Task<Event> Get(string id);

		Task<List<Event>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByAutoId(long autoId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> ByIdOccurred(string id, DateTimeOffset occurred, int limit = int.MaxValue, int offset = 0);

		Task<List<EventRelatedDocument>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5a14ddb2629fe2b6b42a69f2b980a490</Hash>
</Codenesium>*/