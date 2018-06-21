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

                public void SetProperties(
                        int averageLeadTime,
                        int businessEntityID,
                        Nullable<decimal> lastReceiptCost,
                        Nullable<DateTime> lastReceiptDate,
                        int maxOrderQty,
                        int minOrderQty,
                        DateTime modifiedDate,
                        Nullable<int> onOrderQty,
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
                public Nullable<decimal> LastReceiptCost { get; private set; }

                [Column("LastReceiptDate")]
                public Nullable<DateTime> LastReceiptDate { get; private set; }

                [Column("MaxOrderQty")]
                public int MaxOrderQty { get; private set; }

                [Column("MinOrderQty")]
                public int MinOrderQty { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OnOrderQty")]
                public Nullable<int> OnOrderQty { get; private set; }

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
    <Hash>3b71012bf0ee536ea1650d7cbfb3cb3d</Hash>
</Codenesium>*/