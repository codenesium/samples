using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiSchemaAPersonModelMapper
        {
                ApiSchemaAPersonResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaAPersonRequestModel request);

                ApiSchemaAPersonRequestModel MapResponseToRequest(
                        ApiSchemaAPersonResponseModel response);

                JsonPatchDocument<ApiSchemaAPersonRequestModel> CreatePatch(ApiSchemaAPersonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>82ae51bc0b2462849d9836bbf3f3db21</Hash>
</Codenesium>*/