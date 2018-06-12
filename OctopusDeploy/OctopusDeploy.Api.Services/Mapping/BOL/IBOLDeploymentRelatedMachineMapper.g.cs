using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>35deffd47ebc73e9a5b0e6198431227d</Hash>
</Codenesium>*/