using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public interface IApiSpeciesModelMapper
	{
		ApiSpeciesResponseModel MapRequestToResponse(
			int id,
			ApiSpeciesRequestModel request);

		ApiSpeciesRequestModel MapResponseToRequest(
			ApiSpeciesResponseModel response);

		JsonPatchDocument<ApiSpeciesRequestModel> CreatePatch(ApiSpeciesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c395b04fd517e3745845527345df6f0e</Hash>
</Codenesium>*/