using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractExtensionConfigurationMapper
        {
                public virtual BOExtensionConfiguration MapModelToBO(
                        string id,
                        ApiExtensionConfigurationRequestModel model
                        )
                {
                        BOExtensionConfiguration boExtensionConfiguration = new BOExtensionConfiguration();
                        boExtensionConfiguration.SetProperties(
                                id,
                                model.ExtensionAuthor,
                                model.JSON,
                                model.Name);
                        return boExtensionConfiguration;
                }

                public virtual ApiExtensionConfigurationResponseModel MapBOToModel(
                        BOExtensionConfiguration boExtensionConfiguration)
                {
                        var model = new ApiExtensionConfigurationResponseModel();

                        model.SetProperties(boExtensionConfiguration.ExtensionAuthor, boExtensionConfiguration.Id, boExtensionConfiguration.JSON, boExtensionConfiguration.Name);

                        return model;
                }

                public virtual List<ApiExtensionConfigurationResponseModel> MapBOToModel(
                        List<BOExtensionConfiguration> items)
                {
                        List<ApiExtensionConfigurationResponseModel> response = new List<ApiExtensionConfigurationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e8852e195a466aeb3eeb09bcb1ce097e</Hash>
</Codenesium>*/