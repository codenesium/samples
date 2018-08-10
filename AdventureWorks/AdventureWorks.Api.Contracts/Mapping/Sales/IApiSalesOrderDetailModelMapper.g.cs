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
    <Hash>2237a9844a7b9f29ebe750cc71830e71</Hash>
</Codenesium>*/