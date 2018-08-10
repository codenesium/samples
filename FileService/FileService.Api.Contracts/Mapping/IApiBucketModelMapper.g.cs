using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public partial interface IApiBucketModelMapper
	{
		ApiBucketResponseModel MapRequestToResponse(
			int id,
			ApiBucketRequestModel request);

		ApiBucketRequestModel MapResponseToRequest(
			ApiBucketResponseModel response);

		JsonPatchDocument<ApiBucketRequestModel> CreatePatch(ApiBucketRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1318d9604ddf872c2170d67254458fb8</Hash>
</Codenesium>*/