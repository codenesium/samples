using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiExtensionConfigurationModelMapper
        {
                public virtual ApiExtensionConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiExtensionConfigurationRequestModel request)
                {
                        var response = new ApiExtensionConfigurationResponseModel();
                        response.SetProperties(id,
                                               request.ExtensionAuthor,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiExtensionConfigurationRequestModel MapResponseToRequest(
                        ApiExtensionConfigurationResponseModel response)
                {
                        var request = new ApiExtensionConfigurationRequestModel();
                        request.SetProperties(
                                response.ExtensionAuthor,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>327ad2c67d196ae288c6e7208b4f1525</Hash>
</Codenesium>*/