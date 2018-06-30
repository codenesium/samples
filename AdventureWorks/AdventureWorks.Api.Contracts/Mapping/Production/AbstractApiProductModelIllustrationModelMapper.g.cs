using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelIllustrationModelMapper
        {
                public virtual ApiProductModelIllustrationResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel request)
                {
                        var response = new ApiProductModelIllustrationResponseModel();
                        response.SetProperties(productModelID,
                                               request.IllustrationID,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiProductModelIllustrationRequestModel MapResponseToRequest(
                        ApiProductModelIllustrationResponseModel response)
                {
                        var request = new ApiProductModelIllustrationRequestModel();
                        request.SetProperties(
                                response.IllustrationID,
                                response.ModifiedDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>1cf9da47dbbfd0f63ebb8f1ed6013eb1</Hash>
</Codenesium>*/