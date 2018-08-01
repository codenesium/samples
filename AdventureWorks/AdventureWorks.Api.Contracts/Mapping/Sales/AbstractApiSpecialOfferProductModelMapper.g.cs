using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiSpecialOfferProductModelMapper
	{
		public virtual ApiSpecialOfferProductResponseModel MapRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel request)
		{
			var response = new ApiSpecialOfferProductResponseModel();
			response.SetProperties(specialOfferID,
			                       request.ModifiedDate,
			                       request.ProductID,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiSpecialOfferProductRequestModel MapResponseToRequest(
			ApiSpecialOfferProductResponseModel response)
		{
			var request = new ApiSpecialOfferProductRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.ProductID,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiSpecialOfferProductRequestModel> CreatePatch(ApiSpecialOfferProductRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpecialOfferProductRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>deb4ac7a7f2f2719e5bd9e66f7848268</Hash>
</Codenesium>*/