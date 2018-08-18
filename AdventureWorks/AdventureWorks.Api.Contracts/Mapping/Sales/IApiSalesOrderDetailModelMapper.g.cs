using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesOrderDetailModelMapper
	{
		ApiSalesOrderDetailResponseModel MapRequestToResponse(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel request);

		ApiSalesOrderDetailRequestModel MapResponseToRequest(
			ApiSalesOrderDetailResponseModel response);

		JsonPatchDocument<ApiSalesOrderDetailRequestModel> CreatePatch(ApiSalesOrderDetailRequestModel model);
	}
}

/*<Codenesium>
    <Hash>dc5b7ae14cdb2093c046bfa9ff425bfb</Hash>
</Codenesium>*/