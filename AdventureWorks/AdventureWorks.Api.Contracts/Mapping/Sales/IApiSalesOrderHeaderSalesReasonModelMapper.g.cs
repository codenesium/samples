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
    <Hash>bb4333c7bcf26447ea11cc89fd6088fa</Hash>
</Codenesium>*/