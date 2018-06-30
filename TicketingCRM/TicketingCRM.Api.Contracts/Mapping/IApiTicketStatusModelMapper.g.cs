using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTicketStatusModelMapper
        {
                ApiTicketStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketStatusRequestModel request);

                ApiTicketStatusRequestModel MapResponseToRequest(
                        ApiTicketStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a903268518daff7c4a8801ed539dc35e</Hash>
</Codenesium>*/