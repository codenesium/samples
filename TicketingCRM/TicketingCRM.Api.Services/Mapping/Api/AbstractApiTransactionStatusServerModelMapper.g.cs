using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionStatusServerModelMapper
	{
		public virtual ApiTransactionStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionStatusServerRequestModel request)
		{
			var response = new ApiTransactionStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatusServerRequestModel MapServerResponseToRequest(
			ApiTransactionStatusServerResponseModel response)
		{
			var request = new ApiTransactionStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTransactionStatusClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionStatusServerResponseModel response)
		{
			var request = new ApiTransactionStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTransactionStatusServerRequestModel> CreatePatch(ApiTransactionStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ba166c25503be8c29ba27a347dd8f33a</Hash>
</Codenesium>*/