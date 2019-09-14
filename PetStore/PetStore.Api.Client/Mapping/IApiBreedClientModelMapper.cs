using PetStoreNS.Api.Contracts;
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
    <Hash>54ada73bbf3048be6ab644e156174e4f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/