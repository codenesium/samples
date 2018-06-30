using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLConfigurationMapper
        {
                BOConfiguration MapModelToBO(
                        string id,
                        ApiConfigurationRequestModel model);

                ApiConfigurationResponseModel MapBOToModel(
                        BOConfiguration boConfiguration);

                List<ApiConfigurationResponseModel> MapBOToModel(
                        List<BOConfiguration> items);
        }
}

/*<Codenesium>
    <Hash>6faa334d42063936cbca3412219d32aa</Hash>
</Codenesium>*/