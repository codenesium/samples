using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiRateModelMapper
	{
		ApiRateClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRateClientRequestModel request);

		ApiRateClientRequestModel MapClientResponseToRequest(
			ApiRateClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b702e3b14c01a35a7e534a5f0c5695a3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/