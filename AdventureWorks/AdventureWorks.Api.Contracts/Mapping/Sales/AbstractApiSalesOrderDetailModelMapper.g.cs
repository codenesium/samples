using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderDetailModelMapper
        {
                public virtual ApiSalesOrderDetailResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel request)
                {
                        var response = new ApiSalesOrderDetailResponseModel();
                        response.SetProperties(salesOrderID,
                                               request.CarrierTrackingNumber,
                                               request.LineTotal,
                                               request.ModifiedDate,
                                               request.OrderQty,
                                               request.ProductID,
                                               request.Rowguid,
                                               request.SalesOrderDetailID,
                                               request.SpecialOfferID,
                                               request.UnitPrice,
                                               request.UnitPriceDiscount);
                        return response;
                }

                public virtual ApiSalesOrderDetailRequestModel MapResponseToRequest(
                        ApiSalesOrderDetailResponseModel response)
                {
                        var request = new ApiSalesOrderDetailRequestModel();
                        request.SetProperties(
                                response.CarrierTrackingNumber,
                                response.LineTotal,
                                response.ModifiedDate,
                                response.OrderQty,
                                response.ProductID,
                                response.Rowguid,
                                response.SalesOrderDetailID,
                                response.SpecialOfferID,
                                response.UnitPrice,
                                response.UnitPriceDiscount);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>fb1c727a7b6ae0a668b9934b762dc810</Hash>
</Codenesium>*/