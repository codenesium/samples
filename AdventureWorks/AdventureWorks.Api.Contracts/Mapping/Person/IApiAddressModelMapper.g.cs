using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiAddressModelMapper
        {
                ApiAddressResponseModel MapRequestToResponse(
                        int addressID,
                        ApiAddressRequestModel request);

                ApiAddressRequestModel MapResponseToRequest(
                        ApiAddressResponseModel response);
        }
}

/*<Codenesium>
    <Hash>bc468663c00be4168183ee34b5c070cd</Hash>
</Codenesium>*/