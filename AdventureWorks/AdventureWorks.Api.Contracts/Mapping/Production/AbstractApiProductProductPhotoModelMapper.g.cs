using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductProductPhotoModelMapper
        {
                public virtual ApiProductProductPhotoResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductProductPhotoRequestModel request)
                {
                        var response = new ApiProductProductPhotoResponseModel();
                        response.SetProperties(productID,
                                               request.ModifiedDate,
                                               request.Primary,
                                               request.ProductPhotoID);
                        return response;
                }

                public virtual ApiProductProductPhotoRequestModel MapResponseToRequest(
                        ApiProductProductPhotoResponseModel response)
                {
                        var request = new ApiProductProductPhotoRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Primary,
                                response.ProductPhotoID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>6c60464a02270a02ca5396deedf02aaf</Hash>
</Codenesium>*/