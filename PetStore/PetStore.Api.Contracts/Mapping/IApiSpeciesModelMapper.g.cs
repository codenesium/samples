using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public partial interface IApiSpeciesModelMapper
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
    <Hash>4cb6ca77a23a6a2875f42d286c43fee7</Hash>
</Codenesium>*/