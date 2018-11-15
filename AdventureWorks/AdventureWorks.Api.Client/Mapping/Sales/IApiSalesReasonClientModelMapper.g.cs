using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSalesReasonModelMapper
	{
		ApiSalesReasonClientResponseModel MapClientRequestToResponse(
			int salesReasonID,
			ApiSalesReasonClientRequestModel request);

		ApiSalesReasonClientRequestModel MapClientResponseToRequest(
			ApiSalesReasonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f3e01fcf64d867ffc031daa49284ebe5</Hash>
</Codenesium>*/