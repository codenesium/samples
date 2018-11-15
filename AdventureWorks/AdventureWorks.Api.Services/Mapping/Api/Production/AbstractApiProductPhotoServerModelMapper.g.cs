using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductPhotoServerModelMapper
	{
		public virtual ApiProductPhotoServerResponseModel MapServerRequestToResponse(
			int productPhotoID,
			ApiProductPhotoServerRequestModel request)
		{
			var response = new ApiProductPhotoServerResponseModel();
			response.SetProperties(productPhotoID,
			                       request.LargePhoto,
			                       request.LargePhotoFileName,
			                       request.ModifiedDate,
			                       request.ThumbNailPhoto,
			                       request.ThumbnailPhotoFileName);
			return response;
		}

		public virtual ApiProductPhotoServerRequestModel MapServerResponseToRequest(
			ApiProductPhotoServerResponseModel response)
		{
			var request = new ApiProductPhotoServerRequestModel();
			request.SetProperties(
				response.LargePhoto,
				response.LargePhotoFileName,
				response.ModifiedDate,
				response.ThumbNailPhoto,
				response.ThumbnailPhotoFileName);
			return request;
		}

		public virtual ApiProductPhotoClientRequestModel MapServerResponseToClientRequest(
			ApiProductPhotoServerResponseModel response)
		{
			var request = new ApiProductPhotoClientRequestModel();
			request.SetProperties(
				response.LargePhoto,
				response.LargePhotoFileName,
				response.ModifiedDate,
				response.ThumbNailPhoto,
				response.ThumbnailPhotoFileName);
			return request;
		}

		public JsonPatchDocument<ApiProductPhotoServerRequestModel> CreatePatch(ApiProductPhotoServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductPhotoServerRequestModel>();
			patch.Replace(x => x.LargePhoto, model.LargePhoto);
			patch.Replace(x => x.LargePhotoFileName, model.LargePhotoFileName);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ThumbNailPhoto, model.ThumbNailPhoto);
			patch.Replace(x => x.ThumbnailPhotoFileName, model.ThumbnailPhotoFileName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>dfed9307a35c1da1b595b7b1a6e48517</Hash>
</Codenesium>*/