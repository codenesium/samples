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
    <Hash>353f017abfd030c4324b03736be3fa00</Hash>
</Codenesium>*/