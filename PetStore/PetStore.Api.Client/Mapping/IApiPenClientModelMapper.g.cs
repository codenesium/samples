using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public partial interface IApiPenModelMapper
	{
		ApiPenClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPenClientRequestModel request);

		ApiPenClientRequestModel MapClientResponseToRequest(
			ApiPenClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3a7eca88f4e140dd815140c293cb2e1c</Hash>
</Codenesium>*/