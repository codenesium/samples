using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesOrderHeaderModelMapper
	{
		ApiSalesOrderHeaderResponseModel MapRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel request);

		ApiSalesOrderHeaderRequestModel MapResponseToRequest(
			ApiSalesOrderHeaderResponseModel response);

		JsonPatchDocument<ApiSalesOrderHeaderRequestModel> CreatePatch(ApiSalesOrderHeaderRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0f518652d62be571e8eaa3cd4f1cc631</Hash>
</Codenesium>*/