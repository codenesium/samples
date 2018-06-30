using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiSpaceFeatureModelMapper
        {
                public virtual ApiSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceFeatureRequestModel request)
                {
                        var response = new ApiSpaceFeatureResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceFeatureResponseModel response)
                {
                        var request = new ApiSpaceFeatureRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9f944e0347a4a2522c56dad1eb58527f</Hash>
</Codenesium>*/