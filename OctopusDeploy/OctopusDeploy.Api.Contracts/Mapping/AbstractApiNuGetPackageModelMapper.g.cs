using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiNuGetPackageModelMapper
        {
                public virtual ApiNuGetPackageResponseModel MapRequestToResponse(
                        string id,
                        ApiNuGetPackageRequestModel request)
                {
                        var response = new ApiNuGetPackageResponseModel();
                        response.SetProperties(id,
                                               request.JSON,
                                               request.PackageId,
                                               request.Version,
                                               request.VersionBuild,
                                               request.VersionMajor,
                                               request.VersionMinor,
                                               request.VersionRevision,
                                               request.VersionSpecial);
                        return response;
                }

                public virtual ApiNuGetPackageRequestModel MapResponseToRequest(
                        ApiNuGetPackageResponseModel response)
                {
                        var request = new ApiNuGetPackageRequestModel();
                        request.SetProperties(
                                response.JSON,
                                response.PackageId,
                                response.Version,
                                response.VersionBuild,
                                response.VersionMajor,
                                response.VersionMinor,
                                response.VersionRevision,
                                response.VersionSpecial);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>53e5f216be1073de07280a1033e548d4</Hash>
</Codenesium>*/