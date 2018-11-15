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
    <Hash>29315def89c7633561694a5593d8cd03</Hash>
</Codenesium>*/