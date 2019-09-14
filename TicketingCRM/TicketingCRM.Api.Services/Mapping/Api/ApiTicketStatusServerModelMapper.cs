using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatusServerModelMapper : IApiTicketStatusServerModelMapper
	{
		public virtual ApiTicketStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketStatusServerRequestModel request)
		{
			var response = new ApiTicketStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatusServerRequestModel MapServerResponseToRequest(
			ApiTicketStatusServerResponseModel response)
		{
			var request = new ApiTicketStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTicketStatusClientRequestModel MapServerResponseToClientRequest(
			ApiTicketStatusServerResponseModel response)
		{
			var request = new ApiTicketStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTicketStatusServerRequestModel> CreatePatch(ApiTicketStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTicketStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9b2bf6afa07c9b5f1a01fc320d6a8f87</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/