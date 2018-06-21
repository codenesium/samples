using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderRequestModel : AbstractApiRequestModel
        {
                public ApiSalesOrderHeaderRequestModel()
                        : base()
                {
                }

                public void SetProperties(
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

                private string accountNumber;

                public string AccountNumber
                {
                        get
                        {
                                return this.accountNumber.IsEmptyOrZeroOrNull() ? null : this.accountNumber;
                        }

                        set
                        {
                                this.accountNumber = value;
                        }
                }

                private int billToAddressID;

                [Required]
                public int BillToAddressID
                {
                        get
                        {
                                return this.billToAddressID;
                        }

                        set
                        {
                                this.billToAddressID = value;
                        }
                }

                private string comment;

                public string Comment
                {
                        get
                        {
                                return this.comment.IsEmptyOrZeroOrNull() ? null : this.comment;
                        }

                        set
                        {
                                this.comment = value;
                        }
                }

                private string creditCardApprovalCode;

                public string CreditCardApprovalCode
                {
                        get
                        {
                                return this.creditCardApprovalCode.IsEmptyOrZeroOrNull() ? null : this.creditCardApprovalCode;
                        }

                        set
                        {
                                this.creditCardApprovalCode = value;
                        }
                }

                private Nullable<int> creditCardID;

                public Nullable<int> CreditCardID
                {
                        get
                        {
                                return this.creditCardID.IsEmptyOrZeroOrNull() ? null : this.creditCardID;
                        }

                        set
                        {
                                this.creditCardID = value;
                        }
                }

                private Nullable<int> currencyRateID;

                public Nullable<int> CurrencyRateID
                {
                        get
                        {
                                return this.currencyRateID.IsEmptyOrZeroOrNull() ? null : this.currencyRateID;
                        }

                        set
                        {
                                this.currencyRateID = value;
                        }
                }

                private int customerID;

                [Required]
                public int CustomerID
                {
                        get
                        {
                                return this.customerID;
                        }

                        set
                        {
                                this.customerID = value;
                        }
                }

                private DateTime dueDate;

                [Required]
                public DateTime DueDate
                {
                        get
                        {
                                return this.dueDate;
                        }

                        set
                        {
                                this.dueDate = value;
                        }
                }

                private decimal freight;

                [Required]
                public decimal Freight
                {
                        get
                        {
                                return this.freight;
                        }

                        set
                        {
                                this.freight = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private bool onlineOrderFlag;

                [Required]
                public bool OnlineOrderFlag
                {
                        get
                        {
                                return this.onlineOrderFlag;
                        }

                        set
                        {
                                this.onlineOrderFlag = value;
                        }
                }

                private DateTime orderDate;

                [Required]
                public DateTime OrderDate
                {
                        get
                        {
                                return this.orderDate;
                        }

                        set
                        {
                                this.orderDate = value;
                        }
                }

                private string purchaseOrderNumber;

                public string PurchaseOrderNumber
                {
                        get
                        {
                                return this.purchaseOrderNumber.IsEmptyOrZeroOrNull() ? null : this.purchaseOrderNumber;
                        }

                        set
                        {
                                this.purchaseOrderNumber = value;
                        }
                }

                private int revisionNumber;

                [Required]
                public int RevisionNumber
                {
                        get
                        {
                                return this.revisionNumber;
                        }

                        set
                        {
                                this.revisionNumber = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private string salesOrderNumber;

                [Required]
                public string SalesOrderNumber
                {
                        get
                        {
                                return this.salesOrderNumber;
                        }

                        set
                        {
                                this.salesOrderNumber = value;
                        }
                }

                private Nullable<int> salesPersonID;

                public Nullable<int> SalesPersonID
                {
                        get
                        {
                                return this.salesPersonID.IsEmptyOrZeroOrNull() ? null : this.salesPersonID;
                        }

                        set
                        {
                                this.salesPersonID = value;
                        }
                }

                private Nullable<DateTime> shipDate;

                public Nullable<DateTime> ShipDate
                {
                        get
                        {
                                return this.shipDate.IsEmptyOrZeroOrNull() ? null : this.shipDate;
                        }

                        set
                        {
                                this.shipDate = value;
                        }
                }

                private int shipMethodID;

                [Required]
                public int ShipMethodID
                {
                        get
                        {
                                return this.shipMethodID;
                        }

                        set
                        {
                                this.shipMethodID = value;
                        }
                }

                private int shipToAddressID;

                [Required]
                public int ShipToAddressID
                {
                        get
                        {
                                return this.shipToAddressID;
                        }

                        set
                        {
                                this.shipToAddressID = value;
                        }
                }

                private int status;

                [Required]
                public int Status
                {
                        get
                        {
                                return this.status;
                        }

                        set
                        {
                                this.status = value;
                        }
                }

                private decimal subTotal;

                [Required]
                public decimal SubTotal
                {
                        get
                        {
                                return this.subTotal;
                        }

                        set
                        {
                                this.subTotal = value;
                        }
                }

                private decimal taxAmt;

                [Required]
                public decimal TaxAmt
                {
                        get
                        {
                                return this.taxAmt;
                        }

                        set
                        {
                                this.taxAmt = value;
                        }
                }

                private Nullable<int> territoryID;

                public Nullable<int> TerritoryID
                {
                        get
                        {
                                return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }

                private decimal totalDue;

                [Required]
                public decimal TotalDue
                {
                        get
                        {
                                return this.totalDue;
                        }

                        set
                        {
                                this.totalDue = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a28a7deecd831a327d698992d547d1da</Hash>
</Codenesium>*/