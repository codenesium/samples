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
    <Hash>cfeec1c8aa45475dcd3a5e6ee0528fbc</Hash>
</Codenesium>*/