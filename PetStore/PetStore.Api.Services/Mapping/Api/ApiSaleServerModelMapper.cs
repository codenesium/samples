using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiSaleServerModelMapper : IApiSaleServerModelMapper
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
    <Hash>9f0f9621a99f1321aa54225fa9fc47be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/