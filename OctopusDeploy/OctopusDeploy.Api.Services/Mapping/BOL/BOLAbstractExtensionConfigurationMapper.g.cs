using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>a34def4d196c246cf26b666e1e232879</Hash>
</Codenesium>*/