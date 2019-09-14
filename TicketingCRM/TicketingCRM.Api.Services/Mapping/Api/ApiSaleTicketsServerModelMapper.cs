using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiSaleTicketsServerModelMapper : IApiSaleTicketsServerModelMapper
	{
		public virtual ApiSaleTicketsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleTicketsServerRequestModel request)
		{
			var response = new ApiSaleTicketsServerResponseModel();
			response.SetProperties(id,
			                       request.SaleId,
			                       request.TicketId);
			return response;
		}

		public virtual ApiSaleTicketsServerRequestModel MapServerResponseToRequest(
			ApiSaleTicketsServerResponseModel response)
		{
			var request = new ApiSaleTicketsServerRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public virtual ApiSaleTicketsClientRequestModel MapServerResponseToClientRequest(
			ApiSaleTicketsServerResponseModel response)
		{
			var request = new ApiSaleTicketsClientRequestModel();
			request.SetProperties(
				response.SaleId,
				response.TicketId);
			return request;
		}

		public JsonPatchDocument<ApiSaleTicketsServerRequestModel> CreatePatch(ApiSaleTicketsServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleTicketsServerRequestModel>();
			patch.Replace(x => x.SaleId, model.SaleId);
			patch.Replace(x => x.TicketId, model.TicketId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e6a646f1436c68169758af264a0b9c65</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/