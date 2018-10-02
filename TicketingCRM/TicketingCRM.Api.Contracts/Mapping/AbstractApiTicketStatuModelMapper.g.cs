using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiTicketStatuModelMapper
	{
		public virtual ApiTicketStatuResponseModel MapRequestToResponse(
			int id,
			ApiTicketStatuRequestModel request)
		{
			var response = new ApiTicketStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatuRequestModel MapResponseToRequest(
			ApiTicketStatuResponseModel response)
		{
			var request = new ApiTicketStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTicketStatuRequestModel> CreatePatch(ApiTicketStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTicketStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f62406ab1c143c66e95325ecd089e5c2</Hash>
</Codenesium>*/