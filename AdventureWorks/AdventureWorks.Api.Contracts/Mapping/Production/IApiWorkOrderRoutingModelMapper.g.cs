using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiWorkOrderRoutingModelMapper
        {
                ApiWorkOrderRoutingResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRoutingRequestModel request);

                ApiWorkOrderRoutingRequestModel MapResponseToRequest(
                        ApiWorkOrderRoutingResponseModel response);
        }
}

/*<Codenesium>
    <Hash>7defb80a93dd358df27963224fc08155</Hash>
</Codenesium>*/