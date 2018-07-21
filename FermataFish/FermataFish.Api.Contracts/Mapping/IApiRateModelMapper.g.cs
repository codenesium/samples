using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiRateModelMapper
        {
                ApiRateResponseModel MapRequestToResponse(
                        int id,
                        ApiRateRequestModel request);

                ApiRateRequestModel MapResponseToRequest(
                        ApiRateResponseModel response);

                JsonPatchDocument<ApiRateRequestModel> CreatePatch(ApiRateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>38adbfb6835890cdeb20636d7e5d8ba8</Hash>
</Codenesium>*/