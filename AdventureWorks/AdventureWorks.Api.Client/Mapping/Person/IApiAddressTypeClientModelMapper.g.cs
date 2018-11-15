using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiAddressTypeModelMapper
	{
		ApiAddressTypeClientResponseModel MapClientRequestToResponse(
			int addressTypeID,
			ApiAddressTypeClientRequestModel request);

		ApiAddressTypeClientRequestModel MapClientResponseToRequest(
			ApiAddressTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3bd0112b69af45c065c22b63be578f6f</Hash>
</Codenesium>*/