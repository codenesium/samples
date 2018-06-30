using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMutexModelMapper
        {
                ApiMutexResponseModel MapRequestToResponse(
                        string id,
                        ApiMutexRequestModel request);

                ApiMutexRequestModel MapResponseToRequest(
                        ApiMutexResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fa7f992f3881fcf93b3babfdfb47c4ea</Hash>
</Codenesium>*/