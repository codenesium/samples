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
	}
}

/*<Codenesium>
    <Hash>83b0f3f1f452457b5d3944742a3c23a5</Hash>
</Codenesium>*/