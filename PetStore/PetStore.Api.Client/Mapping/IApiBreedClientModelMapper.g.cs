using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public partial interface IApiBreedModelMapper
	{
		ApiBreedClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBreedClientRequestModel request);

		ApiBreedClientRequestModel MapClientResponseToRequest(
			ApiBreedClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>aa539638d174cbcf22f2dd6274d79177</Hash>
</Codenesium>*/