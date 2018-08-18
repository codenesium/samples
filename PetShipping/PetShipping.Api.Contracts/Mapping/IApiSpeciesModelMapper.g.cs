using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
    <Hash>1dcd52e3baa8aaf0ee21af3cb220b92e</Hash>
</Codenesium>*/