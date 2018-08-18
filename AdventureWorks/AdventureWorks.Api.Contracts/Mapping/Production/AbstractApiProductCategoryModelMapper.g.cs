using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductCategoryModelMapper
	{
		public virtual ApiProductCategoryResponseModel MapRequestToResponse(
			int productCategoryID,
			ApiProductCategoryRequestModel request)
		{
			var response = new ApiProductCategoryResponseModel();
			response.SetProperties(productCategoryID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductCategoryRequestModel MapResponseToRequest(
			ApiProductCategoryResponseModel response)
		{
			var request = new ApiProductCategoryRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductCategoryRequestModel> CreatePatch(ApiProductCategoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductCategoryRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ee1dbee5d7215a0e78c740b3257066e8</Hash>
</Codenesium>*/