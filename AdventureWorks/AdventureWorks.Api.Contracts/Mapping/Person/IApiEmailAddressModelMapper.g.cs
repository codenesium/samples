using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmailAddressModelMapper
        {
                ApiEmailAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmailAddressRequestModel request);

                ApiEmailAddressRequestModel MapResponseToRequest(
                        ApiEmailAddressResponseModel response);
        }
}

/*<Codenesium>
    <Hash>41af498f12b40b87bcc4456c98b697d4</Hash>
</Codenesium>*/