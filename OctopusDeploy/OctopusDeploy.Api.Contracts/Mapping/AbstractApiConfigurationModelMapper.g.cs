using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiConfigurationModelMapper
        {
                public virtual ApiConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiConfigurationRequestModel request)
                {
                        var response = new ApiConfigurationResponseModel();
                        response.SetProperties(id,
                                               request.JSON);
                        return response;
                }

                public virtual ApiConfigurationRequestModel MapResponseToRequest(
                        ApiConfigurationResponseModel response)
                {
                        var request = new ApiConfigurationRequestModel();
                        request.SetProperties(
                                response.JSON);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>be93f84ec4e5cd90f1da06488a80cd25</Hash>
</Codenesium>*/