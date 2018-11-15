using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiSaleServerModelMapper
	{
		public virtual ApiSaleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSaleServerRequestModel request)
		{
			var response = new ApiSaleServerResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.CutomerId,
			                       request.Note,
			                       request.PetId,
			                       request.SaleDate,
			                       request.SalesPersonId);
			return response;
		}

		public virtual ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleServerRequestModel();
			request.SetProperties(
				response.Amount,
				response.CutomerId,
				response.Note,
				response.PetId,
				response.SaleDate,
				response.SalesPersonId);
			return request;
		}

		public virtual ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.CutomerId,
				response.Note,
				response.PetId,
				response.SaleDate,
				response.SalesPersonId);
			return request;
		}

		public JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleServerRequestModel>();
			patch.Replace(x => x.Amount, model.Amount);
			patch.Replace(x => x.CutomerId, model.CutomerId);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PetId, model.PetId);
			patch.Replace(x => x.SaleDate, model.SaleDate);
			patch.Replace(x => x.SalesPersonId, model.SalesPersonId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8ce3a8f68792cc94422119d6edcd9dd9</Hash>
</Codenesium>*/