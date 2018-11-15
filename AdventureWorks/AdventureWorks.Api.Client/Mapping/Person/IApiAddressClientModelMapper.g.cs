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
    <Hash>76727cf2fb983fc47f29f8a64f545db4</Hash>
</Codenesium>*/