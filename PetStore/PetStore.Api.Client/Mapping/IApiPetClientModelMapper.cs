using PetStoreNS.Api.Contracts;
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
    <Hash>4cbcd4205414988581d88a5cbce0315c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/