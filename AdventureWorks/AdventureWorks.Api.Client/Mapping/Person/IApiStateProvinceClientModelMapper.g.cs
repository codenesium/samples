using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiStateProvinceModelMapper
	{
		ApiStateProvinceClientResponseModel MapClientRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceClientRequestModel request);

		ApiStateProvinceClientRequestModel MapClientResponseToRequest(
			ApiStateProvinceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>8330ac7123c3309a28a4207811923405</Hash>
</Codenesium>*/