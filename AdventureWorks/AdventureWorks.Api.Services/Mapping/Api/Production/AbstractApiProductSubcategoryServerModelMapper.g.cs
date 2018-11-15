using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductSubcategoryServerModelMapper
	{
		public virtual ApiProductSubcategoryServerResponseModel MapServerRequestToResponse(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel request)
		{
			var response = new ApiProductSubcategoryServerResponseModel();
			response.SetProperties(productSubcategoryID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ProductCategoryID,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductSubcategoryServerRequestModel MapServerResponseToRequest(
			ApiProductSubcategoryServerResponseModel response)
		{
			var request = new ApiProductSubcategoryServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ProductCategoryID,
				response.Rowguid);
			return request;
		}

		public virtual ApiProductSubcategoryClientRequestModel MapServerResponseToClientRequest(
			ApiProductSubcategoryServerResponseModel response)
		{
			var request = new ApiProductSubcategoryClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ProductCategoryID,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductSubcategoryServerRequestModel> CreatePatch(ApiProductSubcategoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductSubcategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProductCategoryID, model.ProductCategoryID);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f814fb6e0c0ba41c5f718b9516b1dd34</Hash>
</Codenesium>*/