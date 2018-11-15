using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiTestAllFieldTypeModelMapper
	{
		ApiTestAllFieldTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTestAllFieldTypeClientRequestModel request);

		ApiTestAllFieldTypeClientRequestModel MapClientResponseToRequest(
			ApiTestAllFieldTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f1077da2dd831d26255dc265bc686c34</Hash>
</Codenesium>*/