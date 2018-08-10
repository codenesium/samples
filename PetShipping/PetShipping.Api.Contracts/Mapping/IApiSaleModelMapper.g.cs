using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiSaleModelMapper
	{
		ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request);

		ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response);

		JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e928a5962cc461cbc1ff40cc77b984a2</Hash>
</Codenesium>*/