using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiLocationModelMapper
        {
                public virtual ApiLocationResponseModel MapRequestToResponse(
                        short locationID,
                        ApiLocationRequestModel request)
                {
                        var response = new ApiLocationResponseModel();
                        response.SetProperties(locationID,
                                               request.Availability,
                                               request.CostRate,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiLocationRequestModel MapResponseToRequest(
                        ApiLocationResponseModel response)
                {
                        var request = new ApiLocationRequestModel();
                        request.SetProperties(
                                response.Availability,
                                response.CostRate,
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a591cf72036f9525058fe8284c6c60f4</Hash>
</Codenesium>*/