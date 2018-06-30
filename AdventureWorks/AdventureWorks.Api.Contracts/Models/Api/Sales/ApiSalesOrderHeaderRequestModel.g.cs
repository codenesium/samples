using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
                                return this.accountNumber;
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
                                return this.comment;
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
                                return this.creditCardApprovalCode;
                        }

                        set
                        {
                                this.creditCardApprovalCode = value;
                        }
                }

                private int? creditCardID;

                public int? CreditCardID
                {
                        get
                        {
                                return this.creditCardID;
                        }

                        set
                        {
                                this.creditCardID = value;
                        }
                }

                private int? currencyRateID;

                public int? CurrencyRateID
                {
                        get
                        {
                                return this.currencyRateID;
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
                                return this.purchaseOrderNumber;
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

                private int? salesPersonID;

                public int? SalesPersonID
                {
                        get
                        {
                                return this.salesPersonID;
                        }

                        set
                        {
                                this.salesPersonID = value;
                        }
                }

                private DateTime? shipDate;

                public DateTime? ShipDate
                {
                        get
                        {
                                return this.shipDate;
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

                private int? territoryID;

                public int? TerritoryID
                {
                        get
                        {
                                return this.territoryID;
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
    <Hash>7f4dfc3a57b215b4afbc4ae4ccf2a6a3</Hash>
</Codenesium>*/