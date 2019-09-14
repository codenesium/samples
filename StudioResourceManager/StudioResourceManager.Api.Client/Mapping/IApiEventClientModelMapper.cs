using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiEventModelMapper
	{
		ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request);

		ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>8f18d65f8d09f4f14ea5c67518b09f7f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/