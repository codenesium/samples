using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiLocationModelMapper
	{
		ApiLocationClientResponseModel MapClientRequestToResponse(
			int locationId,
			ApiLocationClientRequestModel request);

		ApiLocationClientRequestModel MapClientResponseToRequest(
			ApiLocationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7b5e7f306d25e1591db51eccb220bd19</Hash>
</Codenesium>*/