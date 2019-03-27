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
</Codenesium>*/