using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiOtherTransportModelMapper
        {
                ApiOtherTransportResponseModel MapRequestToResponse(
                        int id,
                        ApiOtherTransportRequestModel request);

                ApiOtherTransportRequestModel MapResponseToRequest(
                        ApiOtherTransportResponseModel response);
        }
}

/*<Codenesium>
    <Hash>cd393ee35ef7f56484fa1c9154044057</Hash>
</Codenesium>*/