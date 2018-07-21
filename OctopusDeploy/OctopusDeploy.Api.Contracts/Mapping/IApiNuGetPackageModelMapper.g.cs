using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiNuGetPackageModelMapper
        {
                ApiNuGetPackageResponseModel MapRequestToResponse(
                        string id,
                        ApiNuGetPackageRequestModel request);

                ApiNuGetPackageRequestModel MapResponseToRequest(
                        ApiNuGetPackageResponseModel response);

                JsonPatchDocument<ApiNuGetPackageRequestModel> CreatePatch(ApiNuGetPackageRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7a491c385e124ef2bbabfb81915a81d4</Hash>
</Codenesium>*/