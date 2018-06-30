using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDeploymentEnvironmentMapper
        {
                BODeploymentEnvironment MapModelToBO(
                        string id,
                        ApiDeploymentEnvironmentRequestModel model);

                ApiDeploymentEnvironmentResponseModel MapBOToModel(
                        BODeploymentEnvironment boDeploymentEnvironment);

                List<ApiDeploymentEnvironmentResponseModel> MapBOToModel(
                        List<BODeploymentEnvironment> items);
        }
}

/*<Codenesium>
    <Hash>11e624ab26d4f074540a9984970c5381</Hash>
</Codenesium>*/