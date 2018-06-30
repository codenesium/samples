using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiAccountModelMapper
        {
                ApiAccountResponseModel MapRequestToResponse(
                        string id,
                        ApiAccountRequestModel request);

                ApiAccountRequestModel MapResponseToRequest(
                        ApiAccountResponseModel response);
        }
}

/*<Codenesium>
    <Hash>d584772e0aef334d18c92ce644acc1b9</Hash>
</Codenesium>*/