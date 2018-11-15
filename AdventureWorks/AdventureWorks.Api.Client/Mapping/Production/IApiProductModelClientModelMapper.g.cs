using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductModelModelMapper
	{
		ApiProductModelClientResponseModel MapClientRequestToResponse(
			int productModelID,
			ApiProductModelClientRequestModel request);

		ApiProductModelClientRequestModel MapClientResponseToRequest(
			ApiProductModelClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>048ca0ebba96da5b045efdb8009d727b</Hash>
</Codenesium>*/