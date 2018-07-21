using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceFeatureModelMapper
        {
                ApiSpaceFeatureResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceFeatureRequestModel request);

                ApiSpaceFeatureRequestModel MapResponseToRequest(
                        ApiSpaceFeatureResponseModel response);

                JsonPatchDocument<ApiSpaceFeatureRequestModel> CreatePatch(ApiSpaceFeatureRequestModel model);
        }
}

/*<Codenesium>
    <Hash>967b836700174c1f340e7f3e81f6c066</Hash>
</Codenesium>*/