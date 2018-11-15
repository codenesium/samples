using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiClientCommunicationModelMapper
	{
		ApiClientCommunicationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClientCommunicationClientRequestModel request);

		ApiClientCommunicationClientRequestModel MapClientResponseToRequest(
			ApiClientCommunicationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c9b04b851a6a059ad84a252fa608c924</Hash>
</Codenesium>*/