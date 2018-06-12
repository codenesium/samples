using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractConfigurationMapper
        {
                public virtual BOConfiguration MapModelToBO(
                        string id,
                        ApiConfigurationRequestModel model
                        )
                {
                        BOConfiguration boConfiguration = new BOConfiguration();

                        boConfiguration.SetProperties(
                                id,
                                model.JSON);
                        return boConfiguration;
                }

                public virtual ApiConfigurationResponseModel MapBOToModel(
                        BOConfiguration boConfiguration)
                {
                        var model = new ApiConfigurationResponseModel();

                        model.SetProperties(boConfiguration.Id, boConfiguration.JSON);

                        return model;
                }

                public virtual List<ApiConfigurationResponseModel> MapBOToModel(
                        List<BOConfiguration> items)
                {
                        List<ApiConfigurationResponseModel> response = new List<ApiConfigurationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0e7991e7a116eda173f2089586ad337c</Hash>
</Codenesium>*/