using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public partial interface IApiPetModelMapper
	{
		ApiPetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPetClientRequestModel request);

		ApiPetClientRequestModel MapClientResponseToRequest(
			ApiPetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>11a2198e663e57c89d4d9838057c361a</Hash>
</Codenesium>*/