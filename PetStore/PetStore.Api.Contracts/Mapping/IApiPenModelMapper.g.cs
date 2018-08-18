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
    <Hash>9be125036b01ef5038f500a0c10f560e</Hash>
</Codenesium>*/