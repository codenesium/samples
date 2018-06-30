using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiWorkOrderModelMapper
        {
                ApiWorkOrderResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRequestModel request);

                ApiWorkOrderRequestModel MapResponseToRequest(
                        ApiWorkOrderResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4d4473f7458fc0ffef58851ff075858c</Hash>
</Codenesium>*/