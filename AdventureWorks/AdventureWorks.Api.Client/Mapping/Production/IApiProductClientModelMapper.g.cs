using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductModelMapper
	{
		ApiProductClientResponseModel MapClientRequestToResponse(
			int productID,
			ApiProductClientRequestModel request);

		ApiProductClientRequestModel MapClientResponseToRequest(
			ApiProductClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d872d47d625d696f959810f4aa503d98</Hash>
</Codenesium>*/