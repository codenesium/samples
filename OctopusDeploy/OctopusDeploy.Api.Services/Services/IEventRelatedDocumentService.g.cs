using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IEventRelatedDocumentService
	{
		Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> Create(
			ApiEventRelatedDocumentRequestModel model);

		Task<UpdateResponse<ApiEventRelatedDocumentResponseModel>> Update(int id,
		                                                                   ApiEventRelatedDocumentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventRelatedDocumentResponseModel> Get(int id);

		Task<List<ApiEventRelatedDocumentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventRelatedDocumentResponseModel>> ByEventId(string eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventRelatedDocumentResponseModel>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1f1e9fe03fc1faf15ed6bd0a62943b26</Hash>
</Codenesium>*/