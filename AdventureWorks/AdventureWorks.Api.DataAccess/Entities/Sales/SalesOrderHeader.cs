using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesOrderHeader", Schema="Sales")]
        public partial class SalesOrderHeader : AbstractEntity
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

                [Column("AccountNumber")]
                public string AccountNumber { get; private set; }

                [Column("BillToAddressID")]
                public int BillToAddressID { get; private set; }

                [Column("Comment")]
                public string Comment { get; private set; }

                [Column("CreditCardApprovalCode")]
                public string CreditCardApprovalCode { get; private set; }

                [Column("CreditCardID")]
                public Nullable<int> CreditCardID { get; private set; }

                [Column("CurrencyRateID")]
                public Nullable<int> CurrencyRateID { get; private set; }

                [Column("CustomerID")]
                public int CustomerID { get; private set; }

                [Column("DueDate")]
                public DateTime DueDate { get; private set; }

                [Column("Freight")]
                public decimal Freight { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OnlineOrderFlag")]
                public bool OnlineOrderFlag { get; private set; }

                [Column("OrderDate")]
                public DateTime OrderDate { get; private set; }

                [Column("PurchaseOrderNumber")]
                public string PurchaseOrderNumber { get; private set; }

                [Column("RevisionNumber")]
                public int RevisionNumber { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SalesOrderID")]
                public int SalesOrderID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("SalesOrderNumber")]
                public string SalesOrderNumber { get; private set; }

                [Column("SalesPersonID")]
                public Nullable<int> SalesPersonID { get; private set; }

                [Column("ShipDate")]
                public Nullable<DateTime> ShipDate { get; private set; }

                [Column("ShipMethodID")]
                public int ShipMethodID { get; private set; }

                [Column("ShipToAddressID")]
                public int ShipToAddressID { get; private set; }

                [Column("Status")]
                public int Status { get; private set; }

                [Column("SubTotal")]
                public decimal SubTotal { get; private set; }

                [Column("TaxAmt")]
                public decimal TaxAmt { get; private set; }

                [Column("TerritoryID")]
                public Nullable<int> TerritoryID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("TotalDue")]
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
    <Hash>92d75cb4861122042fb0bbca4cdea6e8</Hash>
</Codenesium>*/