using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiEventRelatedDocumentModelMapper
	{
		ApiEventRelatedDocumentResponseModel MapRequestToResponse(
			int id,
			ApiEventRelatedDocumentRequestModel request);

		ApiEventRelatedDocumentRequestModel MapResponseToRequest(
			ApiEventRelatedDocumentResponseModel response);

		JsonPatchDocument<ApiEventRelatedDocumentRequestModel> CreatePatch(ApiEventRelatedDocumentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>fb4c7065d0938155f08132860bd5920f</Hash>
</Codenesium>*/