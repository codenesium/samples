using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiChainStatusModelMapper
        {
                ApiChainStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiChainStatusRequestModel request);

                ApiChainStatusRequestModel MapResponseToRequest(
                        ApiChainStatusResponseModel response);

                JsonPatchDocument<ApiChainStatusRequestModel> CreatePatch(ApiChainStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>221e564a69a44075ac4ada8270caa7b8</Hash>
</Codenesium>*/