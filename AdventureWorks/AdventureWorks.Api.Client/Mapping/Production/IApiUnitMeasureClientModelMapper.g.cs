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
    <Hash>7a31d5f7023f1d0cc9e02c462bbaa615</Hash>
</Codenesium>*/