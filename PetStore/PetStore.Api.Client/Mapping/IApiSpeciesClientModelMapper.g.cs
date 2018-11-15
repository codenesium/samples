using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
    <Hash>babcbb9a1cf515e800e75c835954fbf0</Hash>
</Codenesium>*/