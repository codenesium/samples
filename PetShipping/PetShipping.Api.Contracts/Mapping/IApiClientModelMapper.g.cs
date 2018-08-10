using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiClientModelMapper
	{
		ApiClientResponseModel MapRequestToResponse(
			int id,
			ApiClientRequestModel request);

		ApiClientRequestModel MapResponseToRequest(
			ApiClientResponseModel response);

		JsonPatchDocument<ApiClientRequestModel> CreatePatch(ApiClientRequestModel model);
	}
}

/*<Codenesium>
    <Hash>68aebfdc48eb81f59f838d8cdd04b7db</Hash>
</Codenesium>*/