using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiTestAllFieldTypeModelMapper
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
    <Hash>d8caef4fb8fcf22140eb4b4a3723aabf</Hash>
</Codenesium>*/