using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>6a4dd77dc1bf13eaba7e9edf5687489c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/