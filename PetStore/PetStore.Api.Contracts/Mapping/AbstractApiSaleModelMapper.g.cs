using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public abstract class AbstractApiSaleModelMapper
	{
		public virtual ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request)
		{
			var response = new ApiSaleResponseModel();
			response.SetProperties(id,
			                       request.Amount,
			                       request.FirstName,
			                       request.LastName,
			                       request.PaymentTypeId,
			                       request.PetId,
			                       request.Phone);
			return response;
		}

		public virtual ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response)
		{
			var request = new ApiSaleRequestModel();
			request.SetProperties(
				response.Amount,
				response.FirstName,
				response.LastName,
				response.PaymentTypeId,
				response.PetId,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleRequestModel>();
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
    <Hash>509d55307441c6d991c883359d07d630</Hash>
</Codenesium>*/