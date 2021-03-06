using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiEventStatusModelMapper
	{
		ApiEventStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatusClientRequestModel request);

		ApiEventStatusClientRequestModel MapClientResponseToRequest(
			ApiEventStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d8702f37a24609e84906f66e4d0b06eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/