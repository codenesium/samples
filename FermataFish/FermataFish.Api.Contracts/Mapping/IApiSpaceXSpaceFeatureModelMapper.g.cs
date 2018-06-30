using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceXSpaceFeatureModelMapper
        {
                ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceXSpaceFeatureRequestModel request);

                ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceXSpaceFeatureResponseModel response);
        }
}

/*<Codenesium>
    <Hash>67bce7f4164cffb6ca76bb53cff4ef3b</Hash>
</Codenesium>*/