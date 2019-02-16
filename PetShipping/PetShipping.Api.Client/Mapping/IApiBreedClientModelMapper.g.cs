using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>a159b735dc426388586c113e789d3022</Hash>
</Codenesium>*/