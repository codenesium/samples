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
    <Hash>1831ebe973adc9bd9aa1dc41c001a7b2</Hash>
</Codenesium>*/