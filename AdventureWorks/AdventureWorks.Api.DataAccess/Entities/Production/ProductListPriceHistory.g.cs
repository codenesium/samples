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
    <Hash>77c7e855c280bb61c9bd3a1abf52fa34</Hash>
</Codenesium>*/