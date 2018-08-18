using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiTransactionStatusModelMapper
	{
		public virtual ApiTransactionStatusResponseModel MapRequestToResponse(
			int id,
			ApiTransactionStatusRequestModel request)
		{
			var response = new ApiTransactionStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTransactionStatusRequestModel MapResponseToRequest(
			ApiTransactionStatusResponseModel response)
		{
			var request = new ApiTransactionStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTransactionStatusRequestModel> CreatePatch(ApiTransactionStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTransactionStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>143c8885bae2555caa9439ca24246d0d</Hash>
</Codenesium>*/