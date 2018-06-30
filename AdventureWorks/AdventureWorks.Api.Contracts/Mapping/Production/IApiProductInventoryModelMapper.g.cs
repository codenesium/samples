using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductInventoryModelMapper
        {
                ApiProductInventoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductInventoryRequestModel request);

                ApiProductInventoryRequestModel MapResponseToRequest(
                        ApiProductInventoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>8740bc554151837981eb2df28cbc12c3</Hash>
</Codenesium>*/