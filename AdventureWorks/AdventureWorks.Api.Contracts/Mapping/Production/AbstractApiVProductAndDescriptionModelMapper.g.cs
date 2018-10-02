using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiVProductAndDescriptionModelMapper
	{
		public virtual ApiVProductAndDescriptionResponseModel MapRequestToResponse(
			string cultureID,
			ApiVProductAndDescriptionRequestModel request)
		{
			var response = new ApiVProductAndDescriptionResponseModel();
			response.SetProperties(cultureID,
			                       request.Description,
			                       request.Name,
			                       request.ProductID,
			                       request.ProductModel);
			return response;
		}

		public virtual ApiVProductAndDescriptionRequestModel MapResponseToRequest(
			ApiVProductAndDescriptionResponseModel response)
		{
			var request = new ApiVProductAndDescriptionRequestModel();
			request.SetProperties(
				response.Description,
				response.Name,
				response.ProductID,
				response.ProductModel);
			return request;
		}

		public JsonPatchDocument<ApiVProductAndDescriptionRequestModel> CreatePatch(ApiVProductAndDescriptionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVProductAndDescriptionRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.ProductModel, model.ProductModel);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ca3573f72261db5ffc4b76b5e53b4bc1</Hash>
</Codenesium>*/