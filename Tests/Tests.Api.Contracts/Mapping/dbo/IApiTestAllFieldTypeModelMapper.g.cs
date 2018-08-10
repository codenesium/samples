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
    <Hash>653e1f3f58b11186270b5cf204ceff37</Hash>
</Codenesium>*/