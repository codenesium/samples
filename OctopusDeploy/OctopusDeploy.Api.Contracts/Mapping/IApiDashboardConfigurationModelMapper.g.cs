using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDashboardConfigurationModelMapper
        {
                ApiDashboardConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiDashboardConfigurationRequestModel request);

                ApiDashboardConfigurationRequestModel MapResponseToRequest(
                        ApiDashboardConfigurationResponseModel response);

                JsonPatchDocument<ApiDashboardConfigurationRequestModel> CreatePatch(ApiDashboardConfigurationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>0a5b6079548f9f2ce4c7dd549ab0a358</Hash>
</Codenesium>*/