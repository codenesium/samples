using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiProvinceModelMapper
        {
                ApiProvinceResponseModel MapRequestToResponse(
                        int id,
                        ApiProvinceRequestModel request);

                ApiProvinceRequestModel MapResponseToRequest(
                        ApiProvinceResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4c19b3be37a41eb15ce9b008b5a15b9d</Hash>
</Codenesium>*/