using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShipMethodModelMapper
        {
                public virtual ApiShipMethodResponseModel MapRequestToResponse(
                        int shipMethodID,
                        ApiShipMethodRequestModel request)
                {
                        var response = new ApiShipMethodResponseModel();
                        response.SetProperties(shipMethodID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid,
                                               request.ShipBase,
                                               request.ShipRate);
                        return response;
                }

                public virtual ApiShipMethodRequestModel MapResponseToRequest(
                        ApiShipMethodResponseModel response)
                {
                        var request = new ApiShipMethodRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid,
                                response.ShipBase,
                                response.ShipRate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>489cb25df1e5c2e78caadc932b2e2993</Hash>
</Codenesium>*/