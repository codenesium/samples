using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketServerModelMapper
	{
		ApiTicketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketServerRequestModel request);

		ApiTicketServerRequestModel MapServerResponseToRequest(
			ApiTicketServerResponseModel response);

		ApiTicketClientRequestModel MapServerResponseToClientRequest(
			ApiTicketServerResponseModel response);

		JsonPatchDocument<ApiTicketServerRequestModel> CreatePatch(ApiTicketServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b9ec2527d4199c7d425634405f7fca84</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/