using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiInterruptionModelMapper
        {
                ApiInterruptionResponseModel MapRequestToResponse(
                        string id,
                        ApiInterruptionRequestModel request);

                ApiInterruptionRequestModel MapResponseToRequest(
                        ApiInterruptionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b644d1df6df8a4da91d7b5883d68af9a</Hash>
</Codenesium>*/