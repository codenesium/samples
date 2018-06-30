using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiContactTypeModelMapper
        {
                public virtual ApiContactTypeResponseModel MapRequestToResponse(
                        int contactTypeID,
                        ApiContactTypeRequestModel request)
                {
                        var response = new ApiContactTypeResponseModel();
                        response.SetProperties(contactTypeID,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiContactTypeRequestModel MapResponseToRequest(
                        ApiContactTypeResponseModel response)
                {
                        var request = new ApiContactTypeRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a6c9c02260a33819641e4883c5a2524f</Hash>
</Codenesium>*/