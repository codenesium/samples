using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiEventModelMapper
        {
                ApiEventResponseModel MapRequestToResponse(
                        string id,
                        ApiEventRequestModel request);

                ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5874a74d13d968ef2063f910b1826e6d</Hash>
</Codenesium>*/