using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesOrderID,
                        string accountNumber,
                        int billToAddressID,
                        string comment,
                        string creditCardApprovalCode,
                        int? creditCardID,
                        int? currencyRateID,
                        int customerID,
                        DateTime dueDate,
                        decimal freight,
                        DateTime modifiedDate,
                        bool onlineOrderFlag,
                        DateTime orderDate,
                        string purchaseOrderNumber,
                        int revisionNumber,
                        Guid rowguid,
                        string salesOrderNumber,
                        int? salesPersonID,
                        DateTime? shipDate,
                        int shipMethodID,
                        int shipToAddressID,
                        int status,
                        decimal subTotal,
                        decimal taxAmt,
                        int? territoryID,
                        decimal totalDue)
                {
                        this.SalesOrderID = salesOrderID;
                        this.AccountNumber = accountNumber;
                        this.BillToAddressID = billToAddressID;
                        this.Comment = comment;
                        this.CreditCardApprovalCode = creditCardApprovalCode;
                        this.CreditCardID = creditCardID;
                        this.CurrencyRateID = currencyRateID;
                        this.CustomerID = customerID;
                        this.DueDate = dueDate;
                        this.Freight = freight;
                        this.ModifiedDate = modifiedDate;
                        this.OnlineOrderFlag = onlineOrderFlag;
                        this.OrderDate = orderDate;
                        this.PurchaseOrderNumber = purchaseOrderNumber;
                        this.RevisionNumber = revisionNumber;
                        this.Rowguid = rowguid;
                        this.SalesOrderNumber = salesOrderNumber;
                        this.SalesPersonID = salesPersonID;
                        this.ShipDate = shipDate;
                        this.ShipMethodID = shipMethodID;
                        this.ShipToAddressID = shipToAddressID;
                        this.Status = status;
                        this.SubTotal = subTotal;
                        this.TaxAmt = taxAmt;
                        this.TerritoryID = territoryID;
                        this.TotalDue = totalDue;

                        this.CreditCardIDEntity = nameof(ApiResponse.CreditCards);
                        this.CurrencyRateIDEntity = nameof(ApiResponse.CurrencyRates);
                        this.CustomerIDEntity = nameof(ApiResponse.Customers);
                        this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public string AccountNumber { get; private set; }

                public int BillToAddressID { get; private set; }

                public string Comment { get; private set; }

                public string CreditCardApprovalCode { get; private set; }

                public int? CreditCardID { get; private set; }

                public string CreditCardIDEntity { get; set; }

                public int? CurrencyRateID { get; private set; }

                public string CurrencyRateIDEntity { get; set; }

                public int CustomerID { get; private set; }

                public string CustomerIDEntity { get; set; }

                public DateTime DueDate { get; private set; }

                public decimal Freight { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public bool OnlineOrderFlag { get; private set; }

                public DateTime OrderDate { get; private set; }

                public string PurchaseOrderNumber { get; private set; }

                public int RevisionNumber { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesOrderID { get; private set; }

                public string SalesOrderNumber { get; private set; }

                public int? SalesPersonID { get; private set; }

                public string SalesPersonIDEntity { get; set; }

                public DateTime? ShipDate { get; private set; }

                public int ShipMethodID { get; private set; }

                public int ShipToAddressID { get; private set; }

                public int Status { get; private set; }

                public decimal SubTotal { get; private set; }

                public decimal TaxAmt { get; private set; }

                public int? TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }

                public decimal TotalDue { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9eb260973b7a4592f492421c980c3264</Hash>
</Codenesium>*/