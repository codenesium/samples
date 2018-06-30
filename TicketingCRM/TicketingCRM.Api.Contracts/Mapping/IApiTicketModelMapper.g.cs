using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTicketModelMapper
        {
                ApiTicketResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketRequestModel request);

                ApiTicketRequestModel MapResponseToRequest(
                        ApiTicketResponseModel response);
        }
}

/*<Codenesium>
    <Hash>2e9364bc3fda7ca89c0b819b1dfbcaa6</Hash>
</Codenesium>*/