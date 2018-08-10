using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiUserModelMapper
	{
		ApiUserResponseModel MapRequestToResponse(
			string id,
			ApiUserRequestModel request);

		ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response);

		JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model);
	}
}

/*<Codenesium>
    <Hash>65278cc5d39ec2de888243400c83dcd0</Hash>
</Codenesium>*/