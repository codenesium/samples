using AdventureWorksNS.Api.Contracts;
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
    <Hash>e586147a3042d84863a816879a15dfc5</Hash>
</Codenesium>*/