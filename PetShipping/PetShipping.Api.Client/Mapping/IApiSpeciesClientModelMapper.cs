using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiSpeciesModelMapper
	{
		ApiSpeciesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpeciesClientRequestModel request);

		ApiSpeciesClientRequestModel MapClientResponseToRequest(
			ApiSpeciesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2270ddecf3ae39b1fa1b02593c52912f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/