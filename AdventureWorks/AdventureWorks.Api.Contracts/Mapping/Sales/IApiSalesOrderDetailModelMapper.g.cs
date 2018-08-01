using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesOrderDetailModelMapper
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
    <Hash>205c8f81cf237b9b013e7425957a253d</Hash>
</Codenesium>*/