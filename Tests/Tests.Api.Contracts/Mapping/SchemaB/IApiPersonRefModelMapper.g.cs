using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiPersonRefModelMapper
	{
		ApiPersonRefResponseModel MapRequestToResponse(
			int id,
			ApiPersonRefRequestModel request);

		ApiPersonRefRequestModel MapResponseToRequest(
			ApiPersonRefResponseModel response);

		JsonPatchDocument<ApiPersonRefRequestModel> CreatePatch(ApiPersonRefRequestModel model);
	}
}

/*<Codenesium>
    <Hash>74ab264fe9ce3c4d01beafdc910062e9</Hash>
</Codenesium>*/