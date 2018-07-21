using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStateModelMapper
        {
                ApiStateResponseModel MapRequestToResponse(
                        int id,
                        ApiStateRequestModel request);

                ApiStateRequestModel MapResponseToRequest(
                        ApiStateResponseModel response);

                JsonPatchDocument<ApiStateRequestModel> CreatePatch(ApiStateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7064852ca0eb69e9efaeb9d66776a404</Hash>
</Codenesium>*/