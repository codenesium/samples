using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCountryModelMapper
        {
                ApiCountryResponseModel MapRequestToResponse(
                        int id,
                        ApiCountryRequestModel request);

                ApiCountryRequestModel MapResponseToRequest(
                        ApiCountryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0d4bcc8f3b94d2898082f6853dee0c3d</Hash>
</Codenesium>*/