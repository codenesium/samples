using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductPhotoModelMapper
	{
		public virtual ApiProductPhotoClientResponseModel MapClientRequestToResponse(
			int productPhotoID,
			ApiProductPhotoClientRequestModel request)
		{
			var response = new ApiProductPhotoClientResponseModel();
			response.SetProperties(productPhotoID,
			                       request.LargePhoto,
			                       request.LargePhotoFileName,
			                       request.ModifiedDate,
			                       request.ThumbNailPhoto,
			                       request.ThumbnailPhotoFileName);
			return response;
		}

		public virtual ApiProductPhotoClientRequestModel MapClientResponseToRequest(
			ApiProductPhotoClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>c45f5dda6416143d516cb120165af799</Hash>
</Codenesium>*/