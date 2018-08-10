using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventResponseModel>> Create(
			ApiEventRequestModel model);

		Task<UpdateResponse<ApiEventResponseModel>> Update(string id,
		                                                    ApiEventRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiEventResponseModel> Get(string id);

		Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> ByAutoId(long autoId);

		Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId);

		Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId);

		Task<List<ApiEventResponseModel>> ByIdOccurred(string id, DateTimeOffset occurred);

		Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bea22e00c0f7a95bb60322e635614a16</Hash>
</Codenesium>*/