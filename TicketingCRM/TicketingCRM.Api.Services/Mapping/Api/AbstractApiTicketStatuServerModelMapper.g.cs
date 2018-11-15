using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTicketStatuServerModelMapper
	{
		public virtual ApiTicketStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketStatuServerRequestModel request)
		{
			var response = new ApiTicketStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatuServerRequestModel MapServerResponseToRequest(
			ApiTicketStatuServerResponseModel response)
		{
			var request = new ApiTicketStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTicketStatuClientRequestModel MapServerResponseToClientRequest(
			ApiTicketStatuServerResponseModel response)
		{
			var request = new ApiTicketStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTicketStatuServerRequestModel> CreatePatch(ApiTicketStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTicketStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d6c2028ade607c0d09f4741bf21c3e99</Hash>
</Codenesium>*/