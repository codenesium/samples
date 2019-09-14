using PetStoreNS.Api.Contracts;
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
    <Hash>fec1da25fb3b940231272086d33bc7bf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/