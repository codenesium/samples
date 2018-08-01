using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiSaleModelMapper
	{
		public virtual ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request)
		{
			var response = new ApiSaleResponseModel();
			response.SetProperties(id,
			                       request.IpAddress,
			                       request.Notes,
			                       request.SaleDate,
			                       request.TransactionId);
			return response;
		}

		public virtual ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response)
		{
			var request = new ApiSaleRequestModel();
			request.SetProperties(
				response.IpAddress,
				response.Notes,
				response.SaleDate,
				response.TransactionId);
			return request;
		}

		public JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleRequestModel>();
			patch.Replace(x => x.IpAddress, model.IpAddress);
			patch.Replace(x => x.Notes, model.Notes);
			patch.Replace(x => x.SaleDate, model.SaleDate);
			patch.Replace(x => x.TransactionId, model.TransactionId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f46a06c728d3daa8b18e8f1d534c689d</Hash>
</Codenesium>*/