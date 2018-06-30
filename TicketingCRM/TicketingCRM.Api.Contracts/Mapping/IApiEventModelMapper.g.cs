using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiEventModelMapper
        {
                ApiEventResponseModel MapRequestToResponse(
                        int id,
                        ApiEventRequestModel request);

                ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4f095682ae5e29b98739244ce5af8c57</Hash>
</Codenesium>*/