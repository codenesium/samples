using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiContactTypeModelMapper
        {
                ApiContactTypeResponseModel MapRequestToResponse(
                        int contactTypeID,
                        ApiContactTypeRequestModel request);

                ApiContactTypeRequestModel MapResponseToRequest(
                        ApiContactTypeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0b240fa552c4c3216e90a7d3b3db480a</Hash>
</Codenesium>*/