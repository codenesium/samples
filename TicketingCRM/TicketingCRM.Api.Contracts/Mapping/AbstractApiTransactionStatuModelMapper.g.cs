using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiTransactionStatuModelMapper
	{
		public virtual ApiTransactionStatuResponseModel MapRequestToResponse(
			int id,
			ApiTransactionStatuRequestModel request)
		{
			var response = new ApiTransactionStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatuRequestModel MapResponseToRequest(
			ApiTransactionStatuResponseModel response)
		{
			var request = new ApiTransactionStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTransactionStatuRequestModel> CreatePatch(ApiTransactionStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ff9680110dbed1790b33b67774fc4e0b</Hash>
</Codenesium>*/