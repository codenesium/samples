using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractDashboardConfigurationMapper
        {
                public virtual BODashboardConfiguration MapModelToBO(
                        string id,
                        ApiDashboardConfigurationRequestModel model
                        )
                {
                        BODashboardConfiguration boDashboardConfiguration = new BODashboardConfiguration();

                        boDashboardConfiguration.SetProperties(
                                id,
                                model.IncludedEnvironmentIds,
                                model.IncludedProjectIds,
                                model.IncludedTenantIds,
                                model.IncludedTenantTags,
                                model.JSON);
                        return boDashboardConfiguration;
                }

                public virtual ApiDashboardConfigurationResponseModel MapBOToModel(
                        BODashboardConfiguration boDashboardConfiguration)
                {
                        var model = new ApiDashboardConfigurationResponseModel();

                        model.SetProperties(boDashboardConfiguration.Id, boDashboardConfiguration.IncludedEnvironmentIds, boDashboardConfiguration.IncludedProjectIds, boDashboardConfiguration.IncludedTenantIds, boDashboardConfiguration.IncludedTenantTags, boDashboardConfiguration.JSON);

                        return model;
                }

                public virtual List<ApiDashboardConfigurationResponseModel> MapBOToModel(
                        List<BODashboardConfiguration> items)
                {
                        List<ApiDashboardConfigurationResponseModel> response = new List<ApiDashboardConfigurationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>52d3a1df1103b6865f534b91937556df</Hash>
</Codenesium>*/