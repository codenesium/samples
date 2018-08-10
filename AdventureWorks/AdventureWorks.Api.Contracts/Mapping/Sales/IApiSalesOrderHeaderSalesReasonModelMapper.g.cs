using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesOrderHeaderSalesReasonModelMapper
	{
		ApiSalesOrderHeaderSalesReasonResponseModel MapRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel request);

		ApiSalesOrderHeaderSalesReasonRequestModel MapResponseToRequest(
			ApiSalesOrderHeaderSalesReasonResponseModel response);

		JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> CreatePatch(ApiSalesOrderHeaderSalesReasonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>683979f676f91ab307e9ce3e00ef8f35</Hash>
</Codenesium>*/