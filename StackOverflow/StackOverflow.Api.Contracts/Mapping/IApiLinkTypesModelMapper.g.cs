using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiLinkTypesModelMapper
        {
                ApiLinkTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkTypesRequestModel request);

                ApiLinkTypesRequestModel MapResponseToRequest(
                        ApiLinkTypesResponseModel response);

                JsonPatchDocument<ApiLinkTypesRequestModel> CreatePatch(ApiLinkTypesRequestModel model);
        }
}

/*<Codenesium>
    <Hash>033a1f0ff26ed72c5be62bb1d2ce31ca</Hash>
</Codenesium>*/