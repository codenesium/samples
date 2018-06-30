using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductSubcategoryModelMapper
        {
                ApiProductSubcategoryResponseModel MapRequestToResponse(
                        int productSubcategoryID,
                        ApiProductSubcategoryRequestModel request);

                ApiProductSubcategoryRequestModel MapResponseToRequest(
                        ApiProductSubcategoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4d07c3ee7ccdb989f755c644170c41f2</Hash>
</Codenesium>*/