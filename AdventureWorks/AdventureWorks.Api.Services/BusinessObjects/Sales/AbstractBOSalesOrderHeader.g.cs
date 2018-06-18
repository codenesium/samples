using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesOrderHeader: AbstractBusinessObject
        {
                public AbstractBOSalesOrderHeader() : base()
                {
                }

                public virtual void SetProperties(int salesOrderID,
                                                  string accountNumber,
                                                  int billToAddressID,
                                                  string comment,
                                                  string creditCardApprovalCode,
                                                  Nullable<int> creditCardID,
                                                  Nullable<int> currencyRateID,
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
                                                  Nullable<int> salesPersonID,
                                                  Nullable<DateTime> shipDate,
                                                  int shipMethodID,
                                                  int shipToAddressID,
                                                  int status,
                                                  decimal subTotal,
                                                  decimal taxAmt,
                                                  Nullable<int> territoryID,
                                                  decimal totalDue)
                {
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
                        this.SalesOrderID = salesOrderID;
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
                }

                public string AccountNumber { get; private set; }

                public int BillToAddressID { get; private set; }

                public string Comment { get; private set; }

                public string CreditCardApprovalCode { get; private set; }

                public Nullable<int> CreditCardID { get; private set; }

                public Nullable<int> CurrencyRateID { get; private set; }

                public int CustomerID { get; private set; }

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

                public Nullable<int> SalesPersonID { get; private set; }

                public Nullable<DateTime> ShipDate { get; private set; }

                public int ShipMethodID { get; private set; }

                public int ShipToAddressID { get; private set; }

                public int Status { get; private set; }

                public decimal SubTotal { get; private set; }

                public decimal TaxAmt { get; private set; }

                public Nullable<int> TerritoryID { get; private set; }

                public decimal TotalDue { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a12af84dc17b51f9493e4a3a48225d2c</Hash>
</Codenesium>*/