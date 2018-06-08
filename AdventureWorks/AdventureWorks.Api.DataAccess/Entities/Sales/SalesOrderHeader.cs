using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesOrderHeader", Schema="Sales")]
        public partial class SalesOrderHeader: AbstractEntity
        {
                public SalesOrderHeader()
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
                        int salesOrderID,
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

                [Column("AccountNumber", TypeName="nvarchar(15)")]
                public string AccountNumber { get; private set; }

                [Column("BillToAddressID", TypeName="int")]
                public int BillToAddressID { get; private set; }

                [Column("Comment", TypeName="nvarchar(128)")]
                public string Comment { get; private set; }

                [Column("CreditCardApprovalCode", TypeName="varchar(15)")]
                public string CreditCardApprovalCode { get; private set; }

                [Column("CreditCardID", TypeName="int")]
                public Nullable<int> CreditCardID { get; private set; }

                [Column("CurrencyRateID", TypeName="int")]
                public Nullable<int> CurrencyRateID { get; private set; }

                [Column("CustomerID", TypeName="int")]
                public int CustomerID { get; private set; }

                [Column("DueDate", TypeName="datetime")]
                public DateTime DueDate { get; private set; }

                [Column("Freight", TypeName="money")]
                public decimal Freight { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OnlineOrderFlag", TypeName="bit")]
                public bool OnlineOrderFlag { get; private set; }

                [Column("OrderDate", TypeName="datetime")]
                public DateTime OrderDate { get; private set; }

                [Column("PurchaseOrderNumber", TypeName="nvarchar(25)")]
                public string PurchaseOrderNumber { get; private set; }

                [Column("RevisionNumber", TypeName="tinyint")]
                public int RevisionNumber { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SalesOrderID", TypeName="int")]
                public int SalesOrderID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("SalesOrderNumber", TypeName="nvarchar(25)")]
                public string SalesOrderNumber { get; private set; }

                [Column("SalesPersonID", TypeName="int")]
                public Nullable<int> SalesPersonID { get; private set; }

                [Column("ShipDate", TypeName="datetime")]
                public Nullable<DateTime> ShipDate { get; private set; }

                [Column("ShipMethodID", TypeName="int")]
                public int ShipMethodID { get; private set; }

                [Column("ShipToAddressID", TypeName="int")]
                public int ShipToAddressID { get; private set; }

                [Column("Status", TypeName="tinyint")]
                public int Status { get; private set; }

                [Column("SubTotal", TypeName="money")]
                public decimal SubTotal { get; private set; }

                [Column("TaxAmt", TypeName="money")]
                public decimal TaxAmt { get; private set; }

                [Column("TerritoryID", TypeName="int")]
                public Nullable<int> TerritoryID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("TotalDue", TypeName="money")]
                public decimal TotalDue { get; private set; }

                [ForeignKey("CreditCardID")]
                public virtual CreditCard CreditCard { get; set; }

                [ForeignKey("CurrencyRateID")]
                public virtual CurrencyRate CurrencyRate { get; set; }

                [ForeignKey("CustomerID")]
                public virtual Customer Customer { get; set; }

                [ForeignKey("SalesPersonID")]
                public virtual SalesPerson SalesPerson { get; set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>bb891e7c32301c30ead7355b23171f4e</Hash>
</Codenesium>*/