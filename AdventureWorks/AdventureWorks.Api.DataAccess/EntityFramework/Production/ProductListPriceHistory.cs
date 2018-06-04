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
		{}

		public void SetProperties(
			Nullable<DateTime> endDate,
			decimal listPrice,
			DateTime modifiedDate,
			int productID,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
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
    <Hash>609bba3af6b9898fbbca6c800e1070ed</Hash>
</Codenesium>*/