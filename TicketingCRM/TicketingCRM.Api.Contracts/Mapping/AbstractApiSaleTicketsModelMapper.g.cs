using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiSaleTicketsModelMapper
	{
		public virtual ApiSaleTicketsResponseModel MapRequestToResponse(
			int id,
			ApiSaleTicketsRequestModel request)
		{
			var response = new ApiSaleTicketsResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketsRequestModel MapResponseToRequest(
			ApiSaleTicketsResponseModel response)
		{
			var request = new ApiSaleTicketsRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public JsonPatchDocument<ApiSaleTicketsRequestModel> CreatePatch(ApiSaleTicketsRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleTicketsRequestModel>();
			patch.Replace(x => x.SaleId, model.SaleId);
			patch.Replace(x => x.TicketId, model.TicketId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a9f03d86a07b3c5a385325c3aea55155</Hash>
</Codenesium>*/