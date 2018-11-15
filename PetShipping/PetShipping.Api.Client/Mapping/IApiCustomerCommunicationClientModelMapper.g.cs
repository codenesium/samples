using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiCustomerCommunicationModelMapper
	{
		ApiCustomerCommunicationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCustomerCommunicationClientRequestModel request);

		ApiCustomerCommunicationClientRequestModel MapClientResponseToRequest(
			ApiCustomerCommunicationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0ad600c14090686050c0458d524115f3</Hash>
</Codenesium>*/