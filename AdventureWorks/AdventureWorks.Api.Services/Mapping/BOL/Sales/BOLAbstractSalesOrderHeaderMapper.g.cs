using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractSalesOrderHeaderMapper
        {
                public virtual BOSalesOrderHeader MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderHeaderRequestModel model
                        )
                {
                        BOSalesOrderHeader boSalesOrderHeader = new BOSalesOrderHeader();
                        boSalesOrderHeader.SetProperties(
                                salesOrderID,
                                model.AccountNumber,
                                model.BillToAddressID,
                                model.Comment,
                                model.CreditCardApprovalCode,
                                model.CreditCardID,
                                model.CurrencyRateID,
                                model.CustomerID,
                                model.DueDate,
                                model.Freight,
                                model.ModifiedDate,
                                model.OnlineOrderFlag,
                                model.OrderDate,
                                model.PurchaseOrderNumber,
                                model.RevisionNumber,
                                model.Rowguid,
                                model.SalesOrderNumber,
                                model.SalesPersonID,
                                model.ShipDate,
                                model.ShipMethodID,
                                model.ShipToAddressID,
                                model.Status,
                                model.SubTotal,
                                model.TaxAmt,
                                model.TerritoryID,
                                model.TotalDue);
                        return boSalesOrderHeader;
                }

                public virtual ApiSalesOrderHeaderResponseModel MapBOToModel(
                        BOSalesOrderHeader boSalesOrderHeader)
                {
                        var model = new ApiSalesOrderHeaderResponseModel();

                        model.SetProperties(boSalesOrderHeader.SalesOrderID, boSalesOrderHeader.AccountNumber, boSalesOrderHeader.BillToAddressID, boSalesOrderHeader.Comment, boSalesOrderHeader.CreditCardApprovalCode, boSalesOrderHeader.CreditCardID, boSalesOrderHeader.CurrencyRateID, boSalesOrderHeader.CustomerID, boSalesOrderHeader.DueDate, boSalesOrderHeader.Freight, boSalesOrderHeader.ModifiedDate, boSalesOrderHeader.OnlineOrderFlag, boSalesOrderHeader.OrderDate, boSalesOrderHeader.PurchaseOrderNumber, boSalesOrderHeader.RevisionNumber, boSalesOrderHeader.Rowguid, boSalesOrderHeader.SalesOrderNumber, boSalesOrderHeader.SalesPersonID, boSalesOrderHeader.ShipDate, boSalesOrderHeader.ShipMethodID, boSalesOrderHeader.ShipToAddressID, boSalesOrderHeader.Status, boSalesOrderHeader.SubTotal, boSalesOrderHeader.TaxAmt, boSalesOrderHeader.TerritoryID, boSalesOrderHeader.TotalDue);

                        return model;
                }

                public virtual List<ApiSalesOrderHeaderResponseModel> MapBOToModel(
                        List<BOSalesOrderHeader> items)
                {
                        List<ApiSalesOrderHeaderResponseModel> response = new List<ApiSalesOrderHeaderResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>dd0b58e8053a101e6ffba251858301d2</Hash>
</Codenesium>*/