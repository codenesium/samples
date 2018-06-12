using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDeploymentHistoryMapper
        {
                BODeploymentHistory MapModelToBO(
                        string deploymentId,
                        ApiDeploymentHistoryRequestModel model);

                ApiDeploymentHistoryResponseModel MapBOToModel(
                        BODeploymentHistory boDeploymentHistory);

                List<ApiDeploymentHistoryResponseModel> MapBOToModel(
                        List<BODeploymentHistory> items);
        }
}

/*<Codenesium>
    <Hash>76547ab30b49e60a7e59d837d55331f1</Hash>
</Codenesium>*/