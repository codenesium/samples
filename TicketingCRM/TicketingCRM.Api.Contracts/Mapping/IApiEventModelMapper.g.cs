using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiEventModelMapper
        {
                ApiEventResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRequestModel request);

                ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response);

                JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d3aea74f7e76cf149ff02b1879ac4aa9</Hash>
</Codenesium>*/