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
    <Hash>117476ebf7b7f88fb4f31787c6ad0b9a</Hash>
</Codenesium>*/