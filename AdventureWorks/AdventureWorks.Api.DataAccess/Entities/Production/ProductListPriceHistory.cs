using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductListPriceHistory", Schema="Production")]
        public partial class ProductListPriceHistory : AbstractEntity
        {
                public ProductListPriceHistory()
                {
                }

                public virtual void SetProperties(
                        DateTime? endDate,
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

                [Column("EndDate")]
                public DateTime? EndDate { get; private set; }

                [Column("ListPrice")]
                public decimal ListPrice { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0926a0ce1a3c79c13785e7bfc34c5129</Hash>
</Codenesium>*/