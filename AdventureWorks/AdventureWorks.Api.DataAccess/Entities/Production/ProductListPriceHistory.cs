using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductListPriceHistory", Schema="Production")]
        public partial class ProductListPriceHistory: AbstractEntity
        {
                public ProductListPriceHistory()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> endDate,
                        decimal listPrice,
                        DateTime modifiedDate,
                        int productID,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StartDate = startDate;
                }

                [Column("EndDate", TypeName="datetime")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ListPrice", TypeName="money")]
                public decimal ListPrice { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("StartDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>49f4d3e63c5e1f55c9b8156dd457e6be</Hash>
</Codenesium>*/