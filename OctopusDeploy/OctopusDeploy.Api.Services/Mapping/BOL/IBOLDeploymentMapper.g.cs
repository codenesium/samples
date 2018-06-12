using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>cdaff52c0737bbff54b815c634d5f243</Hash>
</Codenesium>*/