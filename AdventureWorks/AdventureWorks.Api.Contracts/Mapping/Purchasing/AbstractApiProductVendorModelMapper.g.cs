using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductVendorModelMapper
        {
                public virtual ApiProductVendorResponseModel MapRequestToResponse(
                        int productID,
                        ApiProductVendorRequestModel request)
                {
                        var response = new ApiProductVendorResponseModel();
                        response.SetProperties(productID,
                                               request.AverageLeadTime,
                                               request.BusinessEntityID,
                                               request.LastReceiptCost,
                                               request.LastReceiptDate,
                                               request.MaxOrderQty,
                                               request.MinOrderQty,
                                               request.ModifiedDate,
                                               request.OnOrderQty,
                                               request.StandardPrice,
                                               request.UnitMeasureCode);
                        return response;
                }

                public virtual ApiProductVendorRequestModel MapResponseToRequest(
                        ApiProductVendorResponseModel response)
                {
                        var request = new ApiProductVendorRequestModel();
                        request.SetProperties(
                                response.AverageLeadTime,
                                response.BusinessEntityID,
                                response.LastReceiptCost,
                                response.LastReceiptDate,
                                response.MaxOrderQty,
                                response.MinOrderQty,
                                response.ModifiedDate,
                                response.OnOrderQty,
                                response.StandardPrice,
                                response.UnitMeasureCode);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fa55ca7dfcc337e7a29bd05592d5e55b</Hash>
</Codenesium>*/