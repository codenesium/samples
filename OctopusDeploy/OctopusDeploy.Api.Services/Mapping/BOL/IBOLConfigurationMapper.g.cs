using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>9d592961e617dfd2a226edc887623ab7</Hash>
</Codenesium>*/