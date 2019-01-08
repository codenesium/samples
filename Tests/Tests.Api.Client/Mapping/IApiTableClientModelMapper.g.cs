using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiTableModelMapper
	{
		ApiTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTableClientRequestModel request);

		ApiTableClientRequestModel MapClientResponseToRequest(
			ApiTableClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>aefb0c2d2347c932072d5f1ef8dbf379</Hash>
</Codenesium>*/