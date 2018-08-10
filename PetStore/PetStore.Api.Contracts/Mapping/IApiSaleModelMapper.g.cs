using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
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
    <Hash>ca7db6b7143f0bbc2facc94a054bed6c</Hash>
</Codenesium>*/