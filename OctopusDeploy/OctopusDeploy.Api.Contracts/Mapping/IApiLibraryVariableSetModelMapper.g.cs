using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiLibraryVariableSetModelMapper
        {
                ApiLibraryVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiLibraryVariableSetRequestModel request);

                ApiLibraryVariableSetRequestModel MapResponseToRequest(
                        ApiLibraryVariableSetResponseModel response);

                JsonPatchDocument<ApiLibraryVariableSetRequestModel> CreatePatch(ApiLibraryVariableSetRequestModel model);
        }
}

/*<Codenesium>
    <Hash>cd1a0024661352e571310c6098dbe067</Hash>
</Codenesium>*/