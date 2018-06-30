using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>9d55bd76b21d5cb939d82164763f712e</Hash>
</Codenesium>*/