using PointOfSaleNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Client
{
	public partial interface IApiProductModelMapper
	{
		ApiProductClientResponseModel MapClientRequestToResponse(
			int id,
			ApiProductClientRequestModel request);

		ApiProductClientRequestModel MapClientResponseToRequest(
			ApiProductClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>37cbcd4f97aaee84f61012752b558cbf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/