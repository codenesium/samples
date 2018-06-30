using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiVendorModelMapper
        {
                ApiVendorResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiVendorRequestModel request);

                ApiVendorRequestModel MapResponseToRequest(
                        ApiVendorResponseModel response);
        }
}

/*<Codenesium>
    <Hash>24ec98f842af2424dbe715f08d7eba5c</Hash>
</Codenesium>*/