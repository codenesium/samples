using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesReasonModelMapper
	{
		ApiSalesReasonResponseModel MapRequestToResponse(
			int salesReasonID,
			ApiSalesReasonRequestModel request);

		ApiSalesReasonRequestModel MapResponseToRequest(
			ApiSalesReasonResponseModel response);

		JsonPatchDocument<ApiSalesReasonRequestModel> CreatePatch(ApiSalesReasonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>529b21fba2b3fac0a0423d9263307838</Hash>
</Codenesium>*/