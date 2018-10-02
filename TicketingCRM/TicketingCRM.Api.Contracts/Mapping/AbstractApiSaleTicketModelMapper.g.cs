using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiSaleTicketModelMapper
	{
		public virtual ApiSaleTicketResponseModel MapRequestToResponse(
			int id,
			ApiSaleTicketRequestModel request)
		{
			var response = new ApiSaleTicketResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketRequestModel MapResponseToRequest(
			ApiSaleTicketResponseModel response)
		{
			var request = new ApiSaleTicketRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public JsonPatchDocument<ApiSaleTicketRequestModel> CreatePatch(ApiSaleTicketRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleTicketRequestModel>();
			patch.Replace(x => x.SaleId, model.SaleId);
			patch.Replace(x => x.TicketId, model.TicketId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1d036497666210c4d9854dca9a28ed8a</Hash>
</Codenesium>*/