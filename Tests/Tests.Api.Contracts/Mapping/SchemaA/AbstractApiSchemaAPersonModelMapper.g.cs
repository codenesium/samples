using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public abstract class AbstractApiSchemaAPersonModelMapper
        {
                public virtual ApiSchemaAPersonResponseModel MapRequestToResponse(
                        int id,
                        ApiSchemaAPersonRequestModel request)
                {
                        var response = new ApiSchemaAPersonResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiSchemaAPersonRequestModel MapResponseToRequest(
                        ApiSchemaAPersonResponseModel response)
                {
                        var request = new ApiSchemaAPersonRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }

                public JsonPatchDocument<ApiSchemaAPersonRequestModel> CreatePatch(ApiSchemaAPersonRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSchemaAPersonRequestModel>();
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>85c59d5f5e176f19ba100bf6cb35ef5a</Hash>
</Codenesium>*/