using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractSalesOrderHeaderMapper
        {
                public virtual SalesOrderHeader MapBOToEF(
                        BOSalesOrderHeader bo)
                {
                        SalesOrderHeader efSalesOrderHeader = new SalesOrderHeader();

                        efSalesOrderHeader.SetProperties(
                                bo.AccountNumber,
                                bo.BillToAddressID,
                                bo.Comment,
                                bo.CreditCardApprovalCode,
                                bo.CreditCardID,
                                bo.CurrencyRateID,
                                bo.CustomerID,
                                bo.DueDate,
                                bo.Freight,
                                bo.ModifiedDate,
                                bo.OnlineOrderFlag,
                                bo.OrderDate,
                                bo.PurchaseOrderNumber,
                                bo.RevisionNumber,
                                bo.Rowguid,
                                bo.SalesOrderID,
                                bo.SalesOrderNumber,
                                bo.SalesPersonID,
                                bo.ShipDate,
                                bo.ShipMethodID,
                                bo.ShipToAddressID,
                                bo.Status,
                                bo.SubTotal,
                                bo.TaxAmt,
                                bo.TerritoryID,
                                bo.TotalDue);
                        return efSalesOrderHeader;
                }

                public virtual BOSalesOrderHeader MapEFToBO(
                        SalesOrderHeader ef)
                {
                        var bo = new BOSalesOrderHeader();

                        bo.SetProperties(
                                ef.SalesOrderID,
                                ef.AccountNumber,
                                ef.BillToAddressID,
                                ef.Comment,
                                ef.CreditCardApprovalCode,
                                ef.CreditCardID,
                                ef.CurrencyRateID,
                                ef.CustomerID,
                                ef.DueDate,
                                ef.Freight,
                                ef.ModifiedDate,
                                ef.OnlineOrderFlag,
                                ef.OrderDate,
                                ef.PurchaseOrderNumber,
                                ef.RevisionNumber,
                                ef.Rowguid,
                                ef.SalesOrderNumber,
                                ef.SalesPersonID,
                                ef.ShipDate,
                                ef.ShipMethodID,
                                ef.ShipToAddressID,
                                ef.Status,
                                ef.SubTotal,
                                ef.TaxAmt,
                                ef.TerritoryID,
                                ef.TotalDue);
                        return bo;
                }

                public virtual List<BOSalesOrderHeader> MapEFToBO(
                        List<SalesOrderHeader> records)
                {
                        List<BOSalesOrderHeader> response = new List<BOSalesOrderHeader>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9f863a3fea7558204ab62561e4087893</Hash>
</Codenesium>*/