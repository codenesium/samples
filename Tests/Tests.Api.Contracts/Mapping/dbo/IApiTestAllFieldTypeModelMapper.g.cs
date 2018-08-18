using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiTestAllFieldTypeModelMapper
	{
		ApiTestAllFieldTypeResponseModel MapRequestToResponse(
			int id,
			ApiTestAllFieldTypeRequestModel request);

		ApiTestAllFieldTypeRequestModel MapResponseToRequest(
			ApiTestAllFieldTypeResponseModel response);

		JsonPatchDocument<ApiTestAllFieldTypeRequestModel> CreatePatch(ApiTestAllFieldTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>59e47a64cc17cdfa9869abdfb4d01a55</Hash>
</Codenesium>*/