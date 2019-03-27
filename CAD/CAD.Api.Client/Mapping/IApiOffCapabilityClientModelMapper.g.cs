using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOffCapabilityModelMapper
	{
		ApiOffCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOffCapabilityClientRequestModel request);

		ApiOffCapabilityClientRequestModel MapClientResponseToRequest(
			ApiOffCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>da978a59bbb67c2694c5b8df3fe34dca</Hash>
</Codenesium>*/