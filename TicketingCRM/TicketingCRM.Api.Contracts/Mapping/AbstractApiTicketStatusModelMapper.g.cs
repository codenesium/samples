using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiTicketStatusModelMapper
	{
		public virtual ApiTicketStatusResponseModel MapRequestToResponse(
			int id,
			ApiTicketStatusRequestModel request)
		{
			var response = new ApiTicketStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTicketStatusRequestModel MapResponseToRequest(
			ApiTicketStatusResponseModel response)
		{
			var request = new ApiTicketStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTicketStatusRequestModel> CreatePatch(ApiTicketStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTicketStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cd7b3b1155f476ad2ff5ae22a0262df3</Hash>
</Codenesium>*/