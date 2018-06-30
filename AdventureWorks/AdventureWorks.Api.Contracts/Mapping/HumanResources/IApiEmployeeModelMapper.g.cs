using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeeModelMapper
        {
                ApiEmployeeResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeRequestModel request);

                ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>bcafc3729ca00d795f4fe7b8f92bfa12</Hash>
</Codenesium>*/