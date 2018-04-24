using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCostHistory", Schema="Production")]
	public partial class EFProductCostHistory: AbstractEntityFrameworkPOCO
	{
		public EFProductCostHistory()
		{}

		public void SetProperties(
			int productID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			decimal standardCost,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.StandardCost = standardCost.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>d4e0f0e12414111a5aa41865606500b5</Hash>
</Codenesium>*/