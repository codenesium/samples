using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiConfigurationModelMapper
        {
                ApiConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiConfigurationRequestModel request);

                ApiConfigurationRequestModel MapResponseToRequest(
                        ApiConfigurationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>397771d252b856c92c6509becc6b0da6</Hash>
</Codenesium>*/