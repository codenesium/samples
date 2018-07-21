using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiSpaceModelMapper
        {
                ApiSpaceResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceRequestModel request);

                ApiSpaceRequestModel MapResponseToRequest(
                        ApiSpaceResponseModel response);

                JsonPatchDocument<ApiSpaceRequestModel> CreatePatch(ApiSpaceRequestModel model);
        }
}

/*<Codenesium>
    <Hash>01c38b58541553e1a1ef8326b14dec88</Hash>
</Codenesium>*/