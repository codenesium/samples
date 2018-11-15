using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiClientModelMapper
	{
		ApiClientClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClientClientRequestModel request);

		ApiClientClientRequestModel MapClientResponseToRequest(
			ApiClientClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>640194ba2d5c7c0a4fa09b4e1ba8ee40</Hash>
</Codenesium>*/