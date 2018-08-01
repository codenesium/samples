using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesOrderHeaderModelMapper
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
    <Hash>b8c2d1d4ead471df995db30eda9e37f2</Hash>
</Codenesium>*/