using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c36eb9becc5fc835a691407f18367d7d</Hash>
</Codenesium>*/