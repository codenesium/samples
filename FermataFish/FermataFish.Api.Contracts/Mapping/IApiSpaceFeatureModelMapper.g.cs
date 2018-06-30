using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceFeatureModelMapper
        {
                ApiSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceFeatureRequestModel request);

                ApiSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceFeatureResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4a90bca9ec9637f1793633e38263b4a3</Hash>
</Codenesium>*/