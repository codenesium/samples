using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductListPriceHistory", Schema="Production")]
	public partial class ProductListPriceHistory : AbstractEntity
	{
		public ProductListPriceHistory()
		{
		}

		public virtual void SetProperties(
			int productID,
			DateTime? endDate,
			decimal listPrice,
			DateTime modifiedDate,
			DateTime startDate)
		{
			this.ProductID = productID;
			this.EndDate = endDate;
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate;
			this.StartDate = startDate;
		}

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ListPrice")]
		public virtual decimal ListPrice { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

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
    <Hash>b59f41feb809c61b01189b21264b94a1</Hash>
</Codenesium>*/