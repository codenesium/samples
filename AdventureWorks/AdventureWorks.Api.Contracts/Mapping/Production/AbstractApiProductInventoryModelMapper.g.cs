using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductInventoryModelMapper
        {
                public virtual ApiProductInventoryResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductInventoryRequestModel request)
                {
                        var response = new ApiProductInventoryResponseModel();
                        response.SetProperties(productID,
                                               request.Bin,
                                               request.LocationID,
                                               request.ModifiedDate,
                                               request.Quantity,
                                               request.Rowguid,
                                               request.Shelf);
                        return response;
                }

                public virtual ApiProductInventoryRequestModel MapResponseToRequest(
                        ApiProductInventoryResponseModel response)
                {
                        var request = new ApiProductInventoryRequestModel();
                        request.SetProperties(
                                response.Bin,
                                response.LocationID,
                                response.ModifiedDate,
                                response.Quantity,
                                response.Rowguid,
                                response.Shelf);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>6b619098402d521ffae50e4a3cd0425c</Hash>
</Codenesium>*/