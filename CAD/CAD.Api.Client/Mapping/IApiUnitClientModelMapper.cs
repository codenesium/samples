using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiUnitModelMapper
	{
		ApiUnitClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitClientRequestModel request);

		ApiUnitClientRequestModel MapClientResponseToRequest(
			ApiUnitClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5e8bee2e2975d9c5bc35199b6b8bdde0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/