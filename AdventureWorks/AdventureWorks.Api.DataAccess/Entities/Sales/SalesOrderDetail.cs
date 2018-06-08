using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesOrderDetail", Schema="Sales")]
        public partial class SalesOrderDetail: AbstractEntity
        {
                public SalesOrderDetail()
                {
                }

                public void SetProperties(
                        string carrierTrackingNumber,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        Guid rowguid,
                        int salesOrderDetailID,
                        int salesOrderID,
                        int specialOfferID,
                        decimal unitPrice,
                        decimal unitPriceDiscount)
                {
                        this.CarrierTrackingNumber = carrierTrackingNumber;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SalesOrderDetailID = salesOrderDetailID;
                        this.SalesOrderID = salesOrderID;
                        this.SpecialOfferID = specialOfferID;
                        this.UnitPrice = unitPrice;
                        this.UnitPriceDiscount = unitPriceDiscount;
                }

                [Column("CarrierTrackingNumber", TypeName="nvarchar(25)")]
                public string CarrierTrackingNumber { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("LineTotal", TypeName="decimal")]
                public decimal LineTotal { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty", TypeName="smallint")]
                public short OrderQty { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("SalesOrderDetailID", TypeName="int")]
                public int SalesOrderDetailID { get; private set; }

                [Key]
                [Column("SalesOrderID", TypeName="int")]
                public int SalesOrderID { get; private set; }

                [Column("SpecialOfferID", TypeName="int")]
                public int SpecialOfferID { get; private set; }

                [Column("UnitPrice", TypeName="money")]
                public decimal UnitPrice { get; private set; }

                [Column("UnitPriceDiscount", TypeName="money")]
                public decimal UnitPriceDiscount { get; private set; }

                [ForeignKey("ProductID")]
                public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }

                [ForeignKey("SalesOrderID")]
                public virtual SalesOrderHeader SalesOrderHeader { get; set; }

                [ForeignKey("SpecialOfferID")]
                public virtual SpecialOfferProduct SpecialOfferProduct1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>1d77a68f554511dfbe6e3f3ac75ed6d7</Hash>
</Codenesium>*/