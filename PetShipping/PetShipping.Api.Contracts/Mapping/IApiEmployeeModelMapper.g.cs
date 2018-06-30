using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiEmployeeModelMapper
        {
                ApiEmployeeResponseModel MapRequestToResponse(
                        int id,
                        ApiEmployeeRequestModel request);

                ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>12205e7fa3b7e97efa6fa11296bd97db</Hash>
</Codenesium>*/