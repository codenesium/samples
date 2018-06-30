using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiApiKeyModelMapper
        {
                ApiApiKeyResponseModel MapRequestToResponse(
                        string id,
                        ApiApiKeyRequestModel request);

                ApiApiKeyRequestModel MapResponseToRequest(
                        ApiApiKeyResponseModel response);
        }
}

/*<Codenesium>
    <Hash>bce3e66c0a013495fdd4a551205c21da</Hash>
</Codenesium>*/