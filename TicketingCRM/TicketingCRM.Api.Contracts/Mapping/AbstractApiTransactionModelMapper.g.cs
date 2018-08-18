using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiTransactionModelMapper
	{
		public virtual ApiTransactionResponseModel MapRequestToResponse(
			int id,
			ApiTransactionRequestModel request)
		{
			var response = new ApiTransactionResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.GatewayConfirmationNumber,
			                       request.TransactionStatusId);
			return response;
		}

		public virtual ApiTransactionRequestModel MapResponseToRequest(
			ApiTransactionResponseModel response)
		{
			var request = new ApiTransactionRequestModel();
			request.SetProperties(
				response.Amount,
				response.GatewayConfirmationNumber,
				response.TransactionStatusId);
			return request;
		}

		public JsonPatchDocument<ApiTransactionRequestModel> CreatePatch(ApiTransactionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionRequestModel>();
			patch.Replace(x => x.Amount, model.Amount);
			patch.Replace(x => x.GatewayConfirmationNumber, model.GatewayConfirmationNumber);
			patch.Replace(x => x.TransactionStatusId, model.TransactionStatusId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>db560bcb85987f007db23f21fb67f24b</Hash>
</Codenesium>*/