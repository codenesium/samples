using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiLibraryVariableSetModelMapper
        {
                ApiLibraryVariableSetResponseModel MapRequestToResponse(
                        string id,
                        ApiLibraryVariableSetRequestModel request);

                ApiLibraryVariableSetRequestModel MapResponseToRequest(
                        ApiLibraryVariableSetResponseModel response);
        }
}

/*<Codenesium>
    <Hash>eefcab85fb379310b6ab3a848af75fb8</Hash>
</Codenesium>*/