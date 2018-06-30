using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0fa423e92f4da65780dd254d730b29ed</Hash>
</Codenesium>*/