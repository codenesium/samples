using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiAdminModelMapper
        {
                ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request);

                ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6dd028a8f3b50567f8b709116e103dd9</Hash>
</Codenesium>*/