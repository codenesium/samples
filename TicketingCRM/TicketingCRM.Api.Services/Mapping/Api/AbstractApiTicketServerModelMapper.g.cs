using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTicketServerModelMapper
	{
		public virtual ApiTicketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTicketServerRequestModel request)
		{
			var response = new ApiTicketServerResponseModel();
			response.SetProperties(id,
			                       request.PublicId,
			                       request.TicketStatusId);
			return response;
		}

		public virtual ApiTicketServerRequestModel MapServerResponseToRequest(
			ApiTicketServerResponseModel response)
		{
			var request = new ApiTicketServerRequestModel();
			request.SetProperties(
				response.PublicId,
				response.TicketStatusId);
			return request;
		}

		public virtual ApiTicketClientRequestModel MapServerResponseToClientRequest(
			ApiTicketServerResponseModel response)
		{
			var request = new ApiTicketClientRequestModel();
			request.SetProperties(
				response.PublicId,
				response.TicketStatusId);
			return request;
		}

		public JsonPatchDocument<ApiTicketServerRequestModel> CreatePatch(ApiTicketServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTicketServerRequestModel>();
			patch.Replace(x => x.PublicId, model.PublicId);
			patch.Replace(x => x.TicketStatusId, model.TicketStatusId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>18d99f18521a45d23b9774c808b2cae3</Hash>
</Codenesium>*/