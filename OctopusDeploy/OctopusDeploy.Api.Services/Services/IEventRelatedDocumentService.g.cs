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

		Task<List<ApiEventRelatedDocumentResponseModel>> ByEventId(string eventId);

		Task<List<ApiEventRelatedDocumentResponseModel>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId);
	}
}

/*<Codenesium>
    <Hash>c8a9750498fcdbc216b798b76f958418</Hash>
</Codenesium>*/