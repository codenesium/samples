using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiSpaceModelMapper
	{
		ApiSpaceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceClientRequestModel request);

		ApiSpaceClientRequestModel MapClientResponseToRequest(
			ApiSpaceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5a102a3b28d63b4ac7c2716745bc3190</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/