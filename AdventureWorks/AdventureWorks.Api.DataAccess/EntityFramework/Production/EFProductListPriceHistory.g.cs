using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductListPriceHistory", Schema="Production")]
	public partial class EFProductListPriceHistory: AbstractEntityFrameworkPOCO
	{
		public EFProductListPriceHistory()
		{}

		public void SetProperties(
			int productID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			decimal listPrice,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>be9708a4c2b12c363dbbef365d545a1a</Hash>
</Codenesium>*/