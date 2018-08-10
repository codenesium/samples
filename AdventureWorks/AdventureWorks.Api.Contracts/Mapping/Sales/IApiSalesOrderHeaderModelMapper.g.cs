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
    <Hash>a96570bb5f68fd7529516f80e7389abc</Hash>
</Codenesium>*/