using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiDashboardConfigurationModelMapper
        {
                ApiDashboardConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiDashboardConfigurationRequestModel request);

                ApiDashboardConfigurationRequestModel MapResponseToRequest(
                        ApiDashboardConfigurationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fc3300b3d94d3d9add8af7eeddffdc97</Hash>
</Codenesium>*/