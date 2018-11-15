using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiLocationModelMapper
	{
		ApiLocationClientResponseModel MapClientRequestToResponse(
			short locationID,
			ApiLocationClientRequestModel request);

		ApiLocationClientRequestModel MapClientResponseToRequest(
			ApiLocationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>45cf3587e53d5718c4c8596ba3629651</Hash>
</Codenesium>*/