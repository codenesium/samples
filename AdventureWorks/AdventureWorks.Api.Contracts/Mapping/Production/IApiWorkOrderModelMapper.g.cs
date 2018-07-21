using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiWorkOrderModelMapper
        {
                ApiWorkOrderResponseModel MapRequestToResponse(
                        int workOrderID,
                        ApiWorkOrderRequestModel request);

                ApiWorkOrderRequestModel MapResponseToRequest(
                        ApiWorkOrderResponseModel response);

                JsonPatchDocument<ApiWorkOrderRequestModel> CreatePatch(ApiWorkOrderRequestModel model);
        }
}

/*<Codenesium>
    <Hash>0593a78d32b897fedd055b5150a39db8</Hash>
</Codenesium>*/