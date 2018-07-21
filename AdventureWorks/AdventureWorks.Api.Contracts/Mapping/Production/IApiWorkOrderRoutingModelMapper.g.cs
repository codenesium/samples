using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiWorkOrderRoutingModelMapper
        {
                ApiWorkOrderRoutingResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRoutingRequestModel request);

                ApiWorkOrderRoutingRequestModel MapResponseToRequest(
                        ApiWorkOrderRoutingResponseModel response);

                JsonPatchDocument<ApiWorkOrderRoutingRequestModel> CreatePatch(ApiWorkOrderRoutingRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1590cabbb1e0eed743745af4f0436fdc</Hash>
</Codenesium>*/