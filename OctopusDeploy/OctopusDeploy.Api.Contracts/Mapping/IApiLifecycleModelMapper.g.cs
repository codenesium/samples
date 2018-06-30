using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiLifecycleModelMapper
        {
                ApiLifecycleResponseModel MapRequestToResponse(
                        string id,
                        ApiLifecycleRequestModel request);

                ApiLifecycleRequestModel MapResponseToRequest(
                        ApiLifecycleResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b2aaab6ed745e3e74aa32051cf60cd8e</Hash>
</Codenesium>*/