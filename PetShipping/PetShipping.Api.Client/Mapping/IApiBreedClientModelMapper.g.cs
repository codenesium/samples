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
    <Hash>449b92260cc9efcfc5051330ffce2b80</Hash>
</Codenesium>*/