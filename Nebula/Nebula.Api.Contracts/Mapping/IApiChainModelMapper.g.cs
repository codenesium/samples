using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiChainModelMapper
        {
                ApiChainResponseModel MapRequestToResponse(
                        int id,
                        ApiChainRequestModel request);

                ApiChainRequestModel MapResponseToRequest(
                        ApiChainResponseModel response);

                JsonPatchDocument<ApiChainRequestModel> CreatePatch(ApiChainRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1d7ba1c037b6ef33e77a38ac5be234e6</Hash>
</Codenesium>*/