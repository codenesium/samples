using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductCategoryModelMapper
        {
                ApiProductCategoryResponseModel MapRequestToResponse(
                        int productCategoryID,
                        ApiProductCategoryRequestModel request);

                ApiProductCategoryRequestModel MapResponseToRequest(
                        ApiProductCategoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>688b0d836754e35725f618269c7f44a4</Hash>
</Codenesium>*/