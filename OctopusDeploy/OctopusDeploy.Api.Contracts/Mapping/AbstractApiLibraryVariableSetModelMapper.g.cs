using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiLibraryVariableSetModelMapper
        {
                public virtual ApiLibraryVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiLibraryVariableSetRequestModel request)
                {
                        var response = new ApiLibraryVariableSetResponseModel();
                        response.SetProperties(id,
                                               request.ContentType,
                                               request.JSON,
                                               request.Name,
                                               request.VariableSetId);
                        return response;
                }

                public virtual ApiLibraryVariableSetRequestModel MapResponseToRequest(
                        ApiLibraryVariableSetResponseModel response)
                {
                        var request = new ApiLibraryVariableSetRequestModel();
                        request.SetProperties(
                                response.ContentType,
                                response.JSON,
                                response.Name,
                                response.VariableSetId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>34b18605b9e5d3ffe8ab5729c8510d2f</Hash>
</Codenesium>*/