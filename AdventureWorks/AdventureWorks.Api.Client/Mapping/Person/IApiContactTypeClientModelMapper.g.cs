using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiContactTypeModelMapper
	{
		ApiContactTypeClientResponseModel MapClientRequestToResponse(
			int contactTypeID,
			ApiContactTypeClientRequestModel request);

		ApiContactTypeClientRequestModel MapClientResponseToRequest(
			ApiContactTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a7c89c3815f926f69ab259ff5a5ecc1c</Hash>
</Codenesium>*/