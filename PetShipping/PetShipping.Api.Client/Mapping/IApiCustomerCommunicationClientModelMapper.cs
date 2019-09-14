using PetShippingNS.Api.Contracts;
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
    <Hash>2174526c19fa4f93eb6ffadf07d5fb8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/