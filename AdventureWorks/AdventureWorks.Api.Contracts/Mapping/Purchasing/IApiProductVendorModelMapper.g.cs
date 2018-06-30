using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductVendorModelMapper
        {
                ApiProductVendorResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductVendorRequestModel request);

                ApiProductVendorRequestModel MapResponseToRequest(
                        ApiProductVendorResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6c697a7aa320098a4e652242d4f64aa1</Hash>
</Codenesium>*/