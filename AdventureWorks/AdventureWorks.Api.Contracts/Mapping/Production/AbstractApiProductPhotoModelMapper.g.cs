using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductPhotoModelMapper
	{
		public virtual ApiProductPhotoResponseModel MapRequestToResponse(
			int productPhotoID,
			ApiProductPhotoRequestModel request)
		{
			var response = new ApiProductPhotoResponseModel();
			response.SetProperties(productPhotoID,
			                       request.LargePhoto,
			                       request.LargePhotoFileName,
			                       request.ModifiedDate,
			                       request.ThumbNailPhoto,
			                       request.ThumbnailPhotoFileName);
			return response;
		}

		public virtual ApiProductPhotoRequestModel MapResponseToRequest(
			ApiProductPhotoResponseModel response)
		{
			var request = new ApiProductPhotoRequestModel();
			request.SetProperties(
				response.LargePhoto,
				response.LargePhotoFileName,
				response.ModifiedDate,
				response.ThumbNailPhoto,
				response.ThumbnailPhotoFileName);
			return request;
		}

		public JsonPatchDocument<ApiProductPhotoRequestModel> CreatePatch(ApiProductPhotoRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductPhotoRequestModel>();
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
    <Hash>a43949551e0c0a6d7f3cc1f29df2272c</Hash>
</Codenesium>*/