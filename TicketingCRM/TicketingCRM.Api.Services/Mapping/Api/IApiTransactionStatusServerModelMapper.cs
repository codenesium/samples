using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatusServerModelMapper
	{
		ApiTransactionStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionStatusServerRequestModel request);

		ApiTransactionStatusServerRequestModel MapServerResponseToRequest(
			ApiTransactionStatusServerResponseModel response);

		ApiTransactionStatusClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionStatusServerResponseModel response);

		JsonPatchDocument<ApiTransactionStatusServerRequestModel> CreatePatch(ApiTransactionStatusServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7bbb4154476875b3bfa653375664d8a9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/