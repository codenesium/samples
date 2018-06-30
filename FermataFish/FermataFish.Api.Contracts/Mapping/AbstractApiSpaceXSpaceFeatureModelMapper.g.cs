using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiSpaceXSpaceFeatureModelMapper
        {
                public virtual ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel request)
                {
                        var response = new ApiSpaceXSpaceFeatureResponseModel();
                        response.SetProperties(id,
                                               request.SpaceFeatureId,
                                               request.SpaceId);
                        return response;
                }

                public virtual ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceXSpaceFeatureResponseModel response)
                {
                        var request = new ApiSpaceXSpaceFeatureRequestModel();
                        request.SetProperties(
                                response.SpaceFeatureId,
                                response.SpaceId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f67d34db156a6f540774c8075447c0e4</Hash>
</Codenesium>*/