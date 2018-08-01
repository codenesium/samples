using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductModelProductDescriptionCultureModelMapper
	{
		public virtual ApiProductModelProductDescriptionCultureResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel request)
		{
			var response = new ApiProductModelProductDescriptionCultureResponseModel();
			response.SetProperties(productModelID,
			                       request.CultureID,
			                       request.ModifiedDate,
			                       request.ProductDescriptionID);
			return response;
		}

		public virtual ApiProductModelProductDescriptionCultureRequestModel MapResponseToRequest(
			ApiProductModelProductDescriptionCultureResponseModel response)
		{
			var request = new ApiProductModelProductDescriptionCultureRequestModel();
			request.SetProperties(
				response.CultureID,
				response.ModifiedDate,
				response.ProductDescriptionID);
			return request;
		}

		public JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> CreatePatch(ApiProductModelProductDescriptionCultureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel>();
			patch.Replace(x => x.CultureID, model.CultureID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ProductDescriptionID, model.ProductDescriptionID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8da10a9e648ff01bfa359d796b8c1e3c</Hash>
</Codenesium>*/