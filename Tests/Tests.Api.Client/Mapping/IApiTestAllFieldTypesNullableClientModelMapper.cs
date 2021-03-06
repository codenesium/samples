using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

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
    <Hash>956f6e3a317104dcf562a448c22ff95f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/