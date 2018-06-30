using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProjectModelMapper
        {
                public virtual ApiProjectResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectRequestModel request)
                {
                        var response = new ApiProjectResponseModel();
                        response.SetProperties(id,
                                               request.AutoCreateRelease,
                                               request.DataVersion,
                                               request.DeploymentProcessId,
                                               request.DiscreteChannelRelease,
                                               request.IncludedLibraryVariableSetIds,
                                               request.IsDisabled,
                                               request.JSON,
                                               request.LifecycleId,
                                               request.Name,
                                               request.ProjectGroupId,
                                               request.Slug,
                                               request.VariableSetId);
                        return response;
                }

                public virtual ApiProjectRequestModel MapResponseToRequest(
                        ApiProjectResponseModel response)
                {
                        var request = new ApiProjectRequestModel();
                        request.SetProperties(
                                response.AutoCreateRelease,
                                response.DataVersion,
                                response.DeploymentProcessId,
                                response.DiscreteChannelRelease,
                                response.IncludedLibraryVariableSetIds,
                                response.IsDisabled,
                                response.JSON,
                                response.LifecycleId,
                                response.Name,
                                response.ProjectGroupId,
                                response.Slug,
                                response.VariableSetId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0cc6e486555c5f4f090a61038579a591</Hash>
</Codenesium>*/