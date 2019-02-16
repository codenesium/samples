using AdventureWorksNS.Api.Contracts;
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
    <Hash>ba4cc2712738847e3156237d9dec18cc</Hash>
</Codenesium>*/