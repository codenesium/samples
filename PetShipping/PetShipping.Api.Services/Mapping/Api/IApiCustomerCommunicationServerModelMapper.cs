using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCustomerCommunicationServerModelMapper
	{
		ApiCustomerCommunicationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCustomerCommunicationServerRequestModel request);

		ApiCustomerCommunicationServerRequestModel MapServerResponseToRequest(
			ApiCustomerCommunicationServerResponseModel response);

		ApiCustomerCommunicationClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerCommunicationServerResponseModel response);

		JsonPatchDocument<ApiCustomerCommunicationServerRequestModel> CreatePatch(ApiCustomerCommunicationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4bfaaaf899155d28950ace9d05489b49</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/