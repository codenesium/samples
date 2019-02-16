using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiAddressModelMapper
	{
		ApiAddressClientResponseModel MapClientRequestToResponse(
			int addressID,
			ApiAddressClientRequestModel request);

		ApiAddressClientRequestModel MapClientResponseToRequest(
			ApiAddressClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5d143a59b0de1797b73d2c811edc9e4a</Hash>
</Codenesium>*/