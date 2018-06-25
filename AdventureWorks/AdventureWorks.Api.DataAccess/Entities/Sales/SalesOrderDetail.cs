using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesOrderDetail", Schema="Sales")]
        public partial class SalesOrderDetail : AbstractEntity
        {
                public SalesOrderDetail()
                {
                }

                public virtual void SetProperties(
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

                [Column("CarrierTrackingNumber")]
                public string CarrierTrackingNumber { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("LineTotal")]
                public decimal LineTotal { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty")]
                public short OrderQty { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesOrderDetailID")]
                public int SalesOrderDetailID { get; private set; }

                [Key]
                [Column("SalesOrderID")]
                public int SalesOrderID { get; private set; }

                [Column("SpecialOfferID")]
                public int SpecialOfferID { get; private set; }

                [Column("UnitPrice")]
                public decimal UnitPrice { get; private set; }

                [Column("UnitPriceDiscount")]
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
    <Hash>30c1a0756c6ba1e8cc7ec10f86b9adba</Hash>
</Codenesium>*/