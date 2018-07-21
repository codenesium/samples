using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiSelfReferenceModelMapper
        {
                ApiSelfReferenceResponseModel MapRequestToResponse(
                        int id,
                        ApiSelfReferenceRequestModel request);

                ApiSelfReferenceRequestModel MapResponseToRequest(
                        ApiSelfReferenceResponseModel response);

                JsonPatchDocument<ApiSelfReferenceRequestModel> CreatePatch(ApiSelfReferenceRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9f6b8667be0185f7a86a978839d6158c</Hash>
</Codenesium>*/