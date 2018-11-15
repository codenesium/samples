using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiPasswordModelMapper
	{
		ApiPasswordClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiPasswordClientRequestModel request);

		ApiPasswordClientRequestModel MapClientResponseToRequest(
			ApiPasswordClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>fe87cd1693c9cf29d110beaf87808c16</Hash>
</Codenesium>*/