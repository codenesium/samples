using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiSchemaVersionsModelMapper
        {
                ApiSchemaVersionsResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaVersionsRequestModel request);

                ApiSchemaVersionsRequestModel MapResponseToRequest(
                        ApiSchemaVersionsResponseModel response);

                JsonPatchDocument<ApiSchemaVersionsRequestModel> CreatePatch(ApiSchemaVersionsRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f3557075b766a395e7aa260fe2d29e4d</Hash>
</Codenesium>*/