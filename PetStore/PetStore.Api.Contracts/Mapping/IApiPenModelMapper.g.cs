using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public interface IApiPenModelMapper
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
    <Hash>2c9123d4cde3ad5dfffa68541740c889</Hash>
</Codenesium>*/