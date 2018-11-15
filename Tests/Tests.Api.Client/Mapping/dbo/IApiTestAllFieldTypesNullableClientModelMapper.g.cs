using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiTestAllFieldTypesNullableModelMapper
	{
		ApiTestAllFieldTypesNullableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTestAllFieldTypesNullableClientRequestModel request);

		ApiTestAllFieldTypesNullableClientRequestModel MapClientResponseToRequest(
			ApiTestAllFieldTypesNullableClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d2067b0f80a1023785866a8fabd968a6</Hash>
</Codenesium>*/