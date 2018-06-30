using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiNuGetPackageModelMapper
        {
                ApiNuGetPackageResponseModel MapRequestToResponse(
                        string id,
                        ApiNuGetPackageRequestModel request);

                ApiNuGetPackageRequestModel MapResponseToRequest(
                        ApiNuGetPackageResponseModel response);
        }
}

/*<Codenesium>
    <Hash>638bff924b96179d20c07fa8a77cc348</Hash>
</Codenesium>*/