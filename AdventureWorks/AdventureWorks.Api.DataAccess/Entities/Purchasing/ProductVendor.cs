using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductVendor", Schema="Purchasing")]
        public partial class ProductVendor : AbstractEntity
        {
                public ProductVendor()
                {
                }

                public virtual void SetProperties(
                        int averageLeadTime,
                        int businessEntityID,
                        decimal? lastReceiptCost,
                        DateTime? lastReceiptDate,
                        int maxOrderQty,
                        int minOrderQty,
                        DateTime modifiedDate,
                        int? onOrderQty,
                        int productID,
                        decimal standardPrice,
                        string unitMeasureCode)
                {
                        this.AverageLeadTime = averageLeadTime;
                        this.BusinessEntityID = businessEntityID;
                        this.LastReceiptCost = lastReceiptCost;
                        this.LastReceiptDate = lastReceiptDate;
                        this.MaxOrderQty = maxOrderQty;
                        this.MinOrderQty = minOrderQty;
                        this.ModifiedDate = modifiedDate;
                        this.OnOrderQty = onOrderQty;
                        this.ProductID = productID;
                        this.StandardPrice = standardPrice;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                [Column("AverageLeadTime")]
                public int AverageLeadTime { get; private set; }

                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("LastReceiptCost")]
                public decimal? LastReceiptCost { get; private set; }

                [Column("LastReceiptDate")]
                public DateTime? LastReceiptDate { get; private set; }

                [Column("MaxOrderQty")]
                public int MaxOrderQty { get; private set; }

                [Column("MinOrderQty")]
                public int MinOrderQty { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OnOrderQty")]
                public int? OnOrderQty { get; private set; }

                [Key]
                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("StandardPrice")]
                public decimal StandardPrice { get; private set; }

                [Column("UnitMeasureCode")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>39d5fbee33174bd9eaeba0b592afccb3</Hash>
</Codenesium>*/