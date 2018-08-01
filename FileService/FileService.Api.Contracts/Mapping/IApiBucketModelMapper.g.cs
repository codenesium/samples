using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public interface IApiBucketModelMapper
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
    <Hash>2155ac81e3fc12b7854b3f9e4ae1dee4</Hash>
</Codenesium>*/