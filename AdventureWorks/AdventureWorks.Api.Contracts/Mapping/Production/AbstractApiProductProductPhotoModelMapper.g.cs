using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductProductPhotoModelMapper
	{
		public virtual ApiProductProductPhotoResponseModel MapRequestToResponse(
			int productID,
			ApiProductProductPhotoRequestModel request)
		{
			var response = new ApiProductProductPhotoResponseModel();
			response.SetProperties(productID,
			                       request.ModifiedDate,
			                       request.Primary,
			                       request.ProductPhotoID);
			return response;
		}

		public virtual ApiProductProductPhotoRequestModel MapResponseToRequest(
			ApiProductProductPhotoResponseModel response)
		{
			var request = new ApiProductProductPhotoRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Primary,
				response.ProductPhotoID);
			return request;
		}

		public JsonPatchDocument<ApiProductProductPhotoRequestModel> CreatePatch(ApiProductProductPhotoRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductProductPhotoRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Primary, model.Primary);
			patch.Replace(x => x.ProductPhotoID, model.ProductPhotoID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d254b9dd45044af6577fcacfb15909cd</Hash>
</Codenesium>*/