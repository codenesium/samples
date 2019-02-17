using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTicketStatusServerModelMapper
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
    <Hash>9bb125adba4c05ba68315a259927cf91</Hash>
</Codenesium>*/