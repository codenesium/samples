using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>ccec4d852c76db643f501d9bcd648772</Hash>
</Codenesium>*/