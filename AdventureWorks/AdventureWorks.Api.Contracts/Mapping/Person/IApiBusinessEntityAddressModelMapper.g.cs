using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiBusinessEntityAddressModelMapper
        {
                ApiBusinessEntityAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel request);

                ApiBusinessEntityAddressRequestModel MapResponseToRequest(
                        ApiBusinessEntityAddressResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b8777cac2d89224c983a0b67981ce96f</Hash>
</Codenesium>*/