using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>89e73a5b7d491a41903d01d92bfb63ba</Hash>
</Codenesium>*/