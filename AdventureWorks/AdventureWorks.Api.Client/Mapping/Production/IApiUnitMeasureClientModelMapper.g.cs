using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiUnitMeasureModelMapper
	{
		ApiUnitMeasureClientResponseModel MapClientRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureClientRequestModel request);

		ApiUnitMeasureClientRequestModel MapClientResponseToRequest(
			ApiUnitMeasureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2c6baf3d80cc2632bf17ac22ea939ff5</Hash>
</Codenesium>*/