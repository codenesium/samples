using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiScrapReasonModelMapper
        {
                public virtual ApiScrapReasonResponseModel MapRequestToResponse(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel request)
                {
                        var response = new ApiScrapReasonResponseModel();
                        response.SetProperties(scrapReasonID,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiScrapReasonRequestModel MapResponseToRequest(
                        ApiScrapReasonResponseModel response)
                {
                        var request = new ApiScrapReasonRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fafbf20fb1b0e0ce24834e8adf037834</Hash>
</Codenesium>*/