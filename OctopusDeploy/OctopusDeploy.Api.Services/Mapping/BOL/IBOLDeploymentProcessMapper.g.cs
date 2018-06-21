using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0b4012cbdb7674cfac9d39660d6afa8a</Hash>
</Codenesium>*/