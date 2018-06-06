using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCostHistory", Schema="Production")]
	public partial class ProductCostHistory: AbstractEntity
	{
		public ProductCostHistory()
		{}

		public void SetProperties(
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int productID,
			decimal standardCost,
			DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.StandardCost = standardCost.ToDecimal();
			this.StartDate = startDate.ToDateTime();
		}

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; private set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bbbfa6558bd4d3950e2d440629e6e75d</Hash>
</Codenesium>*/