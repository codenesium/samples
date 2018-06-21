using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDeploymentMapper
        {
                BODeployment MapModelToBO(
                        string id,
                        ApiDeploymentRequestModel model);

                ApiDeploymentResponseModel MapBOToModel(
                        BODeployment boDeployment);

                List<ApiDeploymentResponseModel> MapBOToModel(
                        List<BODeployment> items);
        }
}

/*<Codenesium>
    <Hash>2f79e9ba79d36c2a11dbe7b55c064121</Hash>
</Codenesium>*/