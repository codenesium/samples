using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudioModelMapper
        {
                ApiStudioResponseModel MapRequestToResponse(
                        int id,
                        ApiStudioRequestModel request);

                ApiStudioRequestModel MapResponseToRequest(
                        ApiStudioResponseModel response);

                JsonPatchDocument<ApiStudioRequestModel> CreatePatch(ApiStudioRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1f5cd2c97f942f601cb75232497b8b0c</Hash>
</Codenesium>*/