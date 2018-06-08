using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PurchaseOrderHeader", Schema="Purchasing")]
        public partial class PurchaseOrderHeader: AbstractEntity
        {
                public PurchaseOrderHeader()
                {
                }

                public void SetProperties(
                        int employeeID,
                        decimal freight,
                        DateTime modifiedDate,
                        DateTime orderDate,
                        int purchaseOrderID,
                        int revisionNumber,
                        Nullable<DateTime> shipDate,
                        int shipMethodID,
                        int status,
                        decimal subTotal,
                        decimal taxAmt,
                        decimal totalDue,
                        int vendorID)
                {
                        this.EmployeeID = employeeID;
                        this.Freight = freight;
                        this.ModifiedDate = modifiedDate;
                        this.OrderDate = orderDate;
                        this.PurchaseOrderID = purchaseOrderID;
                        this.RevisionNumber = revisionNumber;
                        this.ShipDate = shipDate;
                        this.ShipMethodID = shipMethodID;
                        this.Status = status;
                        this.SubTotal = subTotal;
                        this.TaxAmt = taxAmt;
                        this.TotalDue = totalDue;
                        this.VendorID = vendorID;
                }

                [Column("EmployeeID", TypeName="int")]
                public int EmployeeID { get; private set; }

                [Column("Freight", TypeName="money")]
                public decimal Freight { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderDate", TypeName="datetime")]
                public DateTime OrderDate { get; private set; }

                [Key]
                [Column("PurchaseOrderID", TypeName="int")]
                public int PurchaseOrderID { get; private set; }

                [Column("RevisionNumber", TypeName="tinyint")]
                public int RevisionNumber { get; private set; }

                [Column("ShipDate", TypeName="datetime")]
                public Nullable<DateTime> ShipDate { get; private set; }

                [Column("ShipMethodID", TypeName="int")]
                public int ShipMethodID { get; private set; }

                [Column("Status", TypeName="tinyint")]
                public int Status { get; private set; }

                [Column("SubTotal", TypeName="money")]
                public decimal SubTotal { get; private set; }

                [Column("TaxAmt", TypeName="money")]
                public decimal TaxAmt { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("TotalDue", TypeName="money")]
                public decimal TotalDue { get; private set; }

                [Column("VendorID", TypeName="int")]
                public int VendorID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bf6231a961ed7bf87907661984af2de1</Hash>
</Codenesium>*/