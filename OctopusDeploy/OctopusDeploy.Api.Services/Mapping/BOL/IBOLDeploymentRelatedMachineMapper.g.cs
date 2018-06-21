using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDeploymentRelatedMachineMapper
        {
                BODeploymentRelatedMachine MapModelToBO(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel model);

                ApiDeploymentRelatedMachineResponseModel MapBOToModel(
                        BODeploymentRelatedMachine boDeploymentRelatedMachine);

                List<ApiDeploymentRelatedMachineResponseModel> MapBOToModel(
                        List<BODeploymentRelatedMachine> items);
        }
}

/*<Codenesium>
    <Hash>b3657c4d65986b20f0eec4beee5bda39</Hash>
</Codenesium>*/