using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductProductPhotoServerModelMapper
	{
		public virtual ApiProductProductPhotoServerResponseModel MapServerRequestToResponse(
			int productID,
			ApiProductProductPhotoServerRequestModel request)
		{
			var response = new ApiProductProductPhotoServerResponseModel();
			response.SetProperties(productID,
			                       request.ModifiedDate,
			                       request.Primary,
			                       request.ProductPhotoID);
			return response;
		}

		public virtual ApiProductProductPhotoServerRequestModel MapServerResponseToRequest(
			ApiProductProductPhotoServerResponseModel response)
		{
			var request = new ApiProductProductPhotoServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Primary,
				response.ProductPhotoID);
			return request;
		}

		public virtual ApiProductProductPhotoClientRequestModel MapServerResponseToClientRequest(
			ApiProductProductPhotoServerResponseModel response)
		{
			var request = new ApiProductProductPhotoClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Primary,
				response.ProductPhotoID);
			return request;
		}

		public JsonPatchDocument<ApiProductProductPhotoServerRequestModel> CreatePatch(ApiProductProductPhotoServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductProductPhotoServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Primary, model.Primary);
			patch.Replace(x => x.ProductPhotoID, model.ProductPhotoID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a2e73d10f3aa3c56c5902cd9e4fed88e</Hash>
</Codenesium>*/