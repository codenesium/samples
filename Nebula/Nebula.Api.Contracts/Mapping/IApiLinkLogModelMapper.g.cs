using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkLogModelMapper
        {
                ApiLinkLogResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkLogRequestModel request);

                ApiLinkLogRequestModel MapResponseToRequest(
                        ApiLinkLogResponseModel response);

                JsonPatchDocument<ApiLinkLogRequestModel> CreatePatch(ApiLinkLogRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e206aa150add287c3dc78614135b7cd8</Hash>
</Codenesium>*/