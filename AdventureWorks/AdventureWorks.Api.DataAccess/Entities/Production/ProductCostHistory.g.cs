using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCostHistory", Schema="Production")]
	public partial class ProductCostHistory : AbstractEntity
	{
		public ProductCostHistory()
		{
		}

		public virtual void SetProperties(
			int productID,
			DateTime? endDate,
			DateTime modifiedDate,
			decimal standardCost,
			DateTime startDate)
		{
			this.ProductID = productID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.StandardCost = standardCost;
			this.StartDate = startDate;
		}

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("StandardCost")]
		public virtual decimal StandardCost { get; private set; }

		[Key]
		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[ForeignKey("ProductID")]
		public virtual Product ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(Product item)
		{
			this.ProductIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>936a779c06b2df8c66fec65ab8489521</Hash>
</Codenesium>*/