using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLExtensionConfigurationMapper
        {
                BOExtensionConfiguration MapModelToBO(
                        string id,
                        ApiExtensionConfigurationRequestModel model);

                ApiExtensionConfigurationResponseModel MapBOToModel(
                        BOExtensionConfiguration boExtensionConfiguration);

                List<ApiExtensionConfigurationResponseModel> MapBOToModel(
                        List<BOExtensionConfiguration> items);
        }
}

/*<Codenesium>
    <Hash>081b1fe1690530f50f41ffb189c7b3b7</Hash>
</Codenesium>*/