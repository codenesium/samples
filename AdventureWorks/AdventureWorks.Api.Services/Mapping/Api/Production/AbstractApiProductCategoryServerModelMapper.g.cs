using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductCategoryServerModelMapper
	{
		public virtual ApiProductCategoryServerResponseModel MapServerRequestToResponse(
			int productCategoryID,
			ApiProductCategoryServerRequestModel request)
		{
			var response = new ApiProductCategoryServerResponseModel();
			response.SetProperties(productCategoryID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductCategoryServerRequestModel MapServerResponseToRequest(
			ApiProductCategoryServerResponseModel response)
		{
			var request = new ApiProductCategoryServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public virtual ApiProductCategoryClientRequestModel MapServerResponseToClientRequest(
			ApiProductCategoryServerResponseModel response)
		{
			var request = new ApiProductCategoryClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductCategoryServerRequestModel> CreatePatch(ApiProductCategoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductCategoryServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5c36b177ee48cb0ce44e5291f40473df</Hash>
</Codenesium>*/