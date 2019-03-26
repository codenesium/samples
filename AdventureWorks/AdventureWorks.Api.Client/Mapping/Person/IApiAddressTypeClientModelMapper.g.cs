using AdventureWorksNS.Api.Contracts;
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
    <Hash>217af3ab003d55c6f625ec8588a17b9a</Hash>
</Codenesium>*/