using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public partial interface IApiPenModelMapper
	{
		ApiPenResponseModel MapRequestToResponse(
			int id,
			ApiPenRequestModel request);

		ApiPenRequestModel MapResponseToRequest(
			ApiPenResponseModel response);

		JsonPatchDocument<ApiPenRequestModel> CreatePatch(ApiPenRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c3f95d11dcf24236366af36debd58300</Hash>
</Codenesium>*/