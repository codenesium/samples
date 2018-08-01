using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiEventRelatedDocumentModelMapper
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
    <Hash>d84e0eb87793fbff463ab5b223b93175</Hash>
</Codenesium>*/