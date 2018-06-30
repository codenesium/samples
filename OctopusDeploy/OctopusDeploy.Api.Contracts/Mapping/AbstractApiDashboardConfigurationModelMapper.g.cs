using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDashboardConfigurationModelMapper
        {
                public virtual ApiDashboardConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiDashboardConfigurationRequestModel request)
                {
                        var response = new ApiDashboardConfigurationResponseModel();
                        response.SetProperties(id,
                                               request.IncludedEnvironmentIds,
                                               request.IncludedProjectIds,
                                               request.IncludedTenantIds,
                                               request.IncludedTenantTags,
                                               request.JSON);
                        return response;
                }

                public virtual ApiDashboardConfigurationRequestModel MapResponseToRequest(
                        ApiDashboardConfigurationResponseModel response)
                {
                        var request = new ApiDashboardConfigurationRequestModel();
                        request.SetProperties(
                                response.IncludedEnvironmentIds,
                                response.IncludedProjectIds,
                                response.IncludedTenantIds,
                                response.IncludedTenantTags,
                                response.JSON);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d59d6a91a3935e97e6185184d1d93d97</Hash>
</Codenesium>*/