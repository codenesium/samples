using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiIllustrationModelMapper
        {
                public virtual ApiIllustrationResponseModel MapRequestToResponse(
                        int illustrationID,
                        ApiIllustrationRequestModel request)
                {
                        var response = new ApiIllustrationResponseModel();
                        response.SetProperties(illustrationID,
                                               request.Diagram,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiIllustrationRequestModel MapResponseToRequest(
                        ApiIllustrationResponseModel response)
                {
                        var request = new ApiIllustrationRequestModel();
                        request.SetProperties(
                                response.Diagram,
                                response.ModifiedDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>810bd1a227dc839e4d94d5cc875042e7</Hash>
</Codenesium>*/