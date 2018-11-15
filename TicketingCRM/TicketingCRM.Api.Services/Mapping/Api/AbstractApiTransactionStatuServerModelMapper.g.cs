using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionStatuServerModelMapper
	{
		public virtual ApiTransactionStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionStatuServerRequestModel request)
		{
			var response = new ApiTransactionStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatuServerRequestModel MapServerResponseToRequest(
			ApiTransactionStatuServerResponseModel response)
		{
			var request = new ApiTransactionStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTransactionStatuClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionStatuServerResponseModel response)
		{
			var request = new ApiTransactionStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTransactionStatuServerRequestModel> CreatePatch(ApiTransactionStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fdde4c3bd591c4d5e97fc583a11dd079</Hash>
</Codenesium>*/