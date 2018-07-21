using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiTestAllFieldTypesNullableModelMapper
        {
                ApiTestAllFieldTypesNullableResponseModel MapRequestToResponse(
                        int id,
                        ApiTestAllFieldTypesNullableRequestModel request);

                ApiTestAllFieldTypesNullableRequestModel MapResponseToRequest(
                        ApiTestAllFieldTypesNullableResponseModel response);

                JsonPatchDocument<ApiTestAllFieldTypesNullableRequestModel> CreatePatch(ApiTestAllFieldTypesNullableRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e471c73c9ff97bb1ee037d9da22fe22b</Hash>
</Codenesium>*/