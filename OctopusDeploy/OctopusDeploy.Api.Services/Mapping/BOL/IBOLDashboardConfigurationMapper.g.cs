using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLDashboardConfigurationMapper
        {
                BODashboardConfiguration MapModelToBO(
                        string id,
                        ApiDashboardConfigurationRequestModel model);

                ApiDashboardConfigurationResponseModel MapBOToModel(
                        BODashboardConfiguration boDashboardConfiguration);

                List<ApiDashboardConfigurationResponseModel> MapBOToModel(
                        List<BODashboardConfiguration> items);
        }
}

/*<Codenesium>
    <Hash>ee0cff50cd69aa8920aef38146a6d117</Hash>
</Codenesium>*/