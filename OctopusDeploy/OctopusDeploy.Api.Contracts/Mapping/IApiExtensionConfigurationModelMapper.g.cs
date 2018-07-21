using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiExtensionConfigurationModelMapper
        {
                ApiExtensionConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiExtensionConfigurationRequestModel request);

                ApiExtensionConfigurationRequestModel MapResponseToRequest(
                        ApiExtensionConfigurationResponseModel response);

                JsonPatchDocument<ApiExtensionConfigurationRequestModel> CreatePatch(ApiExtensionConfigurationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>33845103afa1658bbb9a961be02cbb44</Hash>
</Codenesium>*/