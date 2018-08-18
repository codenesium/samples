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
    <Hash>d45791d744f6073ca1df8d24e6eccd78</Hash>
</Codenesium>*/