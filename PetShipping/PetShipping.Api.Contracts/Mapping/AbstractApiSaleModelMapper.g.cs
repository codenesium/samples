using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
			                       request.ClientId,
			                       request.Note,
			                       request.PetId,
			                       request.SaleDate,
			                       request.SalesPersonId);
			return response;
		}

		public virtual ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response)
		{
			var request = new ApiSaleRequestModel();
			request.SetProperties(
				response.Amount,
				response.ClientId,
				response.Note,
				response.PetId,
				response.SaleDate,
				response.SalesPersonId);
			return request;
		}

		public JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSaleRequestModel>();
			patch.Replace(x => x.Amount, model.Amount);
			patch.Replace(x => x.ClientId, model.ClientId);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PetId, model.PetId);
			patch.Replace(x => x.SaleDate, model.SaleDate);
			patch.Replace(x => x.SalesPersonId, model.SalesPersonId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>764abf4f51a5c49e28c2a1251275d821</Hash>
</Codenesium>*/