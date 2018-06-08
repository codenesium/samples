using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductVendor", Schema="Purchasing")]
        public partial class ProductVendor: AbstractEntity
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

                [Column("AverageLeadTime", TypeName="int")]
                public int AverageLeadTime { get; private set; }

                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("LastReceiptCost", TypeName="money")]
                public Nullable<decimal> LastReceiptCost { get; private set; }

                [Column("LastReceiptDate", TypeName="datetime")]
                public Nullable<DateTime> LastReceiptDate { get; private set; }

                [Column("MaxOrderQty", TypeName="int")]
                public int MaxOrderQty { get; private set; }

                [Column("MinOrderQty", TypeName="int")]
                public int MinOrderQty { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OnOrderQty", TypeName="int")]
                public Nullable<int> OnOrderQty { get; private set; }

                [Key]
                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("StandardPrice", TypeName="money")]
                public decimal StandardPrice { get; private set; }

                [Column("UnitMeasureCode", TypeName="nchar(3)")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9d72816a97391cc6b149fc7fceb39409</Hash>
</Codenesium>*/