using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDeploymentProcessMapper
        {
                BODeploymentProcess MapModelToBO(
                        string id,
                        ApiDeploymentProcessRequestModel model);

                ApiDeploymentProcessResponseModel MapBOToModel(
                        BODeploymentProcess boDeploymentProcess);

                List<ApiDeploymentProcessResponseModel> MapBOToModel(
                        List<BODeploymentProcess> items);
        }
}

/*<Codenesium>
    <Hash>6cc050a6f15e1c6f287d54909e5474d2</Hash>
</Codenesium>*/