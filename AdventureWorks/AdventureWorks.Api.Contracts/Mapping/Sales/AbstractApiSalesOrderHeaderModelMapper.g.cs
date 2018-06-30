using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderHeaderModelMapper
        {
                public virtual ApiSalesOrderHeaderResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderRequestModel request)
                {
                        var response = new ApiSalesOrderHeaderResponseModel();
                        response.SetProperties(salesOrderID,
                                               request.AccountNumber,
                                               request.BillToAddressID,
                                               request.Comment,
                                               request.CreditCardApprovalCode,
                                               request.CreditCardID,
                                               request.CurrencyRateID,
                                               request.CustomerID,
                                               request.DueDate,
                                               request.Freight,
                                               request.ModifiedDate,
                                               request.OnlineOrderFlag,
                                               request.OrderDate,
                                               request.PurchaseOrderNumber,
                                               request.RevisionNumber,
                                               request.Rowguid,
                                               request.SalesOrderNumber,
                                               request.SalesPersonID,
                                               request.ShipDate,
                                               request.ShipMethodID,
                                               request.ShipToAddressID,
                                               request.Status,
                                               request.SubTotal,
                                               request.TaxAmt,
                                               request.TerritoryID,
                                               request.TotalDue);
                        return response;
                }

                public virtual ApiSalesOrderHeaderRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderResponseModel response)
                {
                        var request = new ApiSalesOrderHeaderRequestModel();
                        request.SetProperties(
                                response.AccountNumber,
                                response.BillToAddressID,
                                response.Comment,
                                response.CreditCardApprovalCode,
                                response.CreditCardID,
                                response.CurrencyRateID,
                                response.CustomerID,
                                response.DueDate,
                                response.Freight,
                                response.ModifiedDate,
                                response.OnlineOrderFlag,
                                response.OrderDate,
                                response.PurchaseOrderNumber,
                                response.RevisionNumber,
                                response.Rowguid,
                                response.SalesOrderNumber,
                                response.SalesPersonID,
                                response.ShipDate,
                                response.ShipMethodID,
                                response.ShipToAddressID,
                                response.Status,
                                response.SubTotal,
                                response.TaxAmt,
                                response.TerritoryID,
                                response.TotalDue);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9b2728f4578b8dffb59b89652889f55f</Hash>
</Codenesium>*/