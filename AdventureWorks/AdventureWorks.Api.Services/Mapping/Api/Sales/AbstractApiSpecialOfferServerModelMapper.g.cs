using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSpecialOfferServerModelMapper
	{
		public virtual ApiSpecialOfferServerResponseModel MapServerRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel request)
		{
			var response = new ApiSpecialOfferServerResponseModel();
			response.SetProperties(specialOfferID,
			                       request.Category,
			                       request.Description,
			                       request.DiscountPct,
			                       request.EndDate,
			                       request.MaxQty,
			                       request.MinQty,
			                       request.ModifiedDate,
			                       request.Rowguid,
			                       request.StartDate);
			return response;
		}

		public virtual ApiSpecialOfferServerRequestModel MapServerResponseToRequest(
			ApiSpecialOfferServerResponseModel response)
		{
			var request = new ApiSpecialOfferServerRequestModel();
			request.SetProperties(
				response.Category,
				response.Description,
				response.DiscountPct,
				response.EndDate,
				response.MaxQty,
				response.MinQty,
				response.ModifiedDate,
				response.Rowguid,
				response.StartDate);
			return request;
		}

		public virtual ApiSpecialOfferClientRequestModel MapServerResponseToClientRequest(
			ApiSpecialOfferServerResponseModel response)
		{
			var request = new ApiSpecialOfferClientRequestModel();
			request.SetProperties(
				response.Category,
				response.Description,
				response.DiscountPct,
				response.EndDate,
				response.MaxQty,
				response.MinQty,
				response.ModifiedDate,
				response.Rowguid,
				response.StartDate);
			return request;
		}

		public JsonPatchDocument<ApiSpecialOfferServerRequestModel> CreatePatch(ApiSpecialOfferServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpecialOfferServerRequestModel>();
			patch.Replace(x => x.Category, model.Category);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.DiscountPct, model.DiscountPct);
			patch.Replace(x => x.EndDate, model.EndDate);
			patch.Replace(x => x.MaxQty, model.MaxQty);
			patch.Replace(x => x.MinQty, model.MinQty);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.StartDate, model.StartDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4e6b2f7af3681d088554593d86cf60b7</Hash>
</Codenesium>*/