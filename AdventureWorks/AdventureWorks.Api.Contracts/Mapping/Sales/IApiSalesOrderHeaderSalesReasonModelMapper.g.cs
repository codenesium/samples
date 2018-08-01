using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesOrderHeaderSalesReasonModelMapper
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
    <Hash>005965309912329223ed37c28c8c36e2</Hash>
</Codenesium>*/