using AdventureWorksNS.Api.Contracts;
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
    <Hash>09f19627a1499ae6f82299ef0a169877</Hash>
</Codenesium>*/