using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionServerModelMapper
	{
		public virtual ApiTransactionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTransactionServerRequestModel request)
		{
			var response = new ApiTransactionServerResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.GatewayConfirmationNumber,
			                       request.TransactionStatusId);
			return response;
		}

		public virtual ApiTransactionServerRequestModel MapServerResponseToRequest(
			ApiTransactionServerResponseModel response)
		{
			var request = new ApiTransactionServerRequestModel();
			request.SetProperties(
				response.Amount,
				response.GatewayConfirmationNumber,
				response.TransactionStatusId);
			return request;
		}

		public virtual ApiTransactionClientRequestModel MapServerResponseToClientRequest(
			ApiTransactionServerResponseModel response)
		{
			var request = new ApiTransactionClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.GatewayConfirmationNumber,
				response.TransactionStatusId);
			return request;
		}

		public JsonPatchDocument<ApiTransactionServerRequestModel> CreatePatch(ApiTransactionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionServerRequestModel>();
			patch.Replace(x => x.Amount, model.Amount);
			patch.Replace(x => x.GatewayConfirmationNumber, model.GatewayConfirmationNumber);
			patch.Replace(x => x.TransactionStatusId, model.TransactionStatusId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b1bee0fd3f3ecb6a7891957e97474f0d</Hash>
</Codenesium>*/