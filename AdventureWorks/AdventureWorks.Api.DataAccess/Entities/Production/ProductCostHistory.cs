using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductCostHistory", Schema="Production")]
        public partial class ProductCostHistory : AbstractEntity
        {
                public ProductCostHistory()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int productID,
                        decimal standardCost,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StandardCost = standardCost;
                        this.StartDate = startDate;
                }

                [Column("EndDate")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("StandardCost")]
                public decimal StandardCost { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>db46445bdb94b63de9cc954c35699251</Hash>
</Codenesium>*/