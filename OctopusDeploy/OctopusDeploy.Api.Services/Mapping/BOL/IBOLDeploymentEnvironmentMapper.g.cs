using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>0de566548ce58982d5715e77b11c09c2</Hash>
</Codenesium>*/