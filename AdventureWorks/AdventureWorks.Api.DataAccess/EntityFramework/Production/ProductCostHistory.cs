using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCostHistory", Schema="Production")]
	public partial class ProductCostHistory: AbstractEntityFrameworkPOCO
	{
		public ProductCostHistory()
		{}

		public void SetProperties(
			int productID,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
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
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>c94a9c6b7397cff4a9e644d784fa8eee</Hash>
</Codenesium>*/