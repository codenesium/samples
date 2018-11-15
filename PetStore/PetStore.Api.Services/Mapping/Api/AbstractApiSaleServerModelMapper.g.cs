using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
			                       request.FirstName,
			                       request.LastName,
			                       request.PaymentTypeId,
			                       request.PetId,
			                       request.Phone);
			return response;
		}

		public virtual ApiSaleServerRequestModel MapServerResponseToRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleServerRequestModel();
			request.SetProperties(
				response.Amount,
				response.FirstName,
				response.LastName,
				response.PaymentTypeId,
				response.PetId,
				response.Phone);
			return request;
		}

		public virtual ApiSaleClientRequestModel MapServerResponseToClientRequest(
			ApiSaleServerResponseModel response)
		{
			var request = new ApiSaleClientRequestModel();
			request.SetProperties(
				response.Amount,
				response.FirstName,
				response.LastName,
				response.PaymentTypeId,
				response.PetId,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiSaleServerRequestModel> CreatePatch(ApiSaleServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleServerRequestModel>();
			patch.Replace(x => x.Amount, model.Amount);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.PaymentTypeId, model.PaymentTypeId);
			patch.Replace(x => x.PetId, model.PetId);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ec52505d678fb64b4ccc66049f9faeb3</Hash>
</Codenesium>*/