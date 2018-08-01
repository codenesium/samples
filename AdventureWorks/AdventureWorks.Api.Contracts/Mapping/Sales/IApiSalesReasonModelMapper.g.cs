using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesReasonModelMapper
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
    <Hash>bf971b2a19a27f54877d941c6686f9f9</Hash>
</Codenesium>*/