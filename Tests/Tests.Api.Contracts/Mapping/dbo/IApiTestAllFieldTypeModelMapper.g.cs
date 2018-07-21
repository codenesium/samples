using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiTestAllFieldTypeModelMapper
        {
                ApiTestAllFieldTypeResponseModel MapRequestToResponse(
                        int id,
                        ApiTestAllFieldTypeRequestModel request);

                ApiTestAllFieldTypeRequestModel MapResponseToRequest(
                        ApiTestAllFieldTypeResponseModel response);

                JsonPatchDocument<ApiTestAllFieldTypeRequestModel> CreatePatch(ApiTestAllFieldTypeRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6dbbbf26d7b3fb1e08128504b2d07eb5</Hash>
</Codenesium>*/