using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiSaleTicketServerModelMapper
	{
		public virtual ApiSaleTicketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleTicketServerRequestModel request)
		{
			var response = new ApiSaleTicketServerResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketServerRequestModel MapServerResponseToRequest(
			ApiSaleTicketServerResponseModel response)
		{
			var request = new ApiSaleTicketServerRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public virtual ApiSaleTicketClientRequestModel MapServerResponseToClientRequest(
			ApiSaleTicketServerResponseModel response)
		{
			var request = new ApiSaleTicketClientRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public JsonPatchDocument<ApiSaleTicketServerRequestModel> CreatePatch(ApiSaleTicketServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleTicketServerRequestModel>();
			patch.Replace(x => x.SaleId, model.SaleId);
			patch.Replace(x => x.TicketId, model.TicketId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>51351a2ee7e7cac7301afeb0ae6505c6</Hash>
</Codenesium>*/