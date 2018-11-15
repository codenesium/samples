using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiSaleServerModelMapper
	{
		public virtual ApiSaleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleServerRequestModel request)
		{
			var response = new ApiSaleServerResponseModel();
			response.SetProperties(id,
			                       request.IpAddress,
			                       request.Note,
			                       request.SaleDate,
			                       request.TransactionId);
			return response;
		}

		public virtual ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleServerRequestModel();
			request.SetProperties(
				response.IpAddress,
				response.Note,
				response.SaleDate,
				response.TransactionId);
			return request;
		}

		public virtual ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.IpAddress,
				response.Note,
				response.SaleDate,
				response.TransactionId);
			return request;
		}

		public JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleServerRequestModel>();
			patch.Replace(x => x.IpAddress, model.IpAddress);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.SaleDate, model.SaleDate);
			patch.Replace(x => x.TransactionId, model.TransactionId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7e0732750bfefcd0d910c6fa41e5e285</Hash>
</Codenesium>*/