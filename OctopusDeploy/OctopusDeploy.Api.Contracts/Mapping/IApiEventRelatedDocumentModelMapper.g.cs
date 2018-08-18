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
    <Hash>b246ef2af62e7a37f1cee33c88ad3b0f</Hash>
</Codenesium>*/