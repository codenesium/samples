using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiVenueModelMapper
        {
                ApiVenueResponseModel MapRequestToResponse(
                        int id,
                        ApiVenueRequestModel request);

                ApiVenueRequestModel MapResponseToRequest(
                        ApiVenueResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a436b8ed54f072ba3c0dfa9720833982</Hash>
</Codenesium>*/