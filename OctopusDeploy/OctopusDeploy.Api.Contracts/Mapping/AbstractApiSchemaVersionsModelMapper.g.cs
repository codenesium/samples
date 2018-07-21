using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiSchemaVersionsModelMapper
        {
                public virtual ApiSchemaVersionsResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaVersionsRequestModel request)
                {
                        var response = new ApiSchemaVersionsResponseModel();
                        response.SetProperties(id,
                                               request.Applied,
                                               request.ScriptName);
                        return response;
                }

                public virtual ApiSchemaVersionsRequestModel MapResponseToRequest(
                        ApiSchemaVersionsResponseModel response)
                {
                        var request = new ApiSchemaVersionsRequestModel();
                        request.SetProperties(
                                response.Applied,
                                response.ScriptName);
                        return request;
                }

                public JsonPatchDocument<ApiSchemaVersionsRequestModel> CreatePatch(ApiSchemaVersionsRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSchemaVersionsRequestModel>();
                        patch.Replace(x => x.Applied, model.Applied);
                        patch.Replace(x => x.ScriptName, model.ScriptName);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>79735a82f988a7c1b724f2c7e0409a81</Hash>
</Codenesium>*/