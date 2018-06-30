using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPurchaseOrderHeaderModelMapper
        {
                public virtual ApiPurchaseOrderHeaderResponseModel MapRequestToResponse(
                        int purchaseOrderID,
                        ApiPurchaseOrderHeaderRequestModel request)
                {
                        var response = new ApiPurchaseOrderHeaderResponseModel();
                        response.SetProperties(purchaseOrderID,
                                               request.EmployeeID,
                                               request.Freight,
                                               request.ModifiedDate,
                                               request.OrderDate,
                                               request.RevisionNumber,
                                               request.ShipDate,
                                               request.ShipMethodID,
                                               request.Status,
                                               request.SubTotal,
                                               request.TaxAmt,
                                               request.TotalDue,
                                               request.VendorID);
                        return response;
                }

                public virtual ApiPurchaseOrderHeaderRequestModel MapResponseToRequest(
                        ApiPurchaseOrderHeaderResponseModel response)
                {
                        var request = new ApiPurchaseOrderHeaderRequestModel();
                        request.SetProperties(
                                response.EmployeeID,
                                response.Freight,
                                response.ModifiedDate,
                                response.OrderDate,
                                response.RevisionNumber,
                                response.ShipDate,
                                response.ShipMethodID,
                                response.Status,
                                response.SubTotal,
                                response.TaxAmt,
                                response.TotalDue,
                                response.VendorID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0a6fe68053056646a7b4a1ee909a47a4</Hash>
</Codenesium>*/