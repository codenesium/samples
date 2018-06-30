using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiExtensionConfigurationModelMapper
        {
                ApiExtensionConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiExtensionConfigurationRequestModel request);

                ApiExtensionConfigurationRequestModel MapResponseToRequest(
                        ApiExtensionConfigurationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>7e3d36b478bd30ef3e1f29293b35228d</Hash>
</Codenesium>*/