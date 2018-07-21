using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkModelMapper
        {
                ApiLinkResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkRequestModel request);

                ApiLinkRequestModel MapResponseToRequest(
                        ApiLinkResponseModel response);

                JsonPatchDocument<ApiLinkRequestModel> CreatePatch(ApiLinkRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3a43723df21639be68342ddd9c3531d8</Hash>
</Codenesium>*/