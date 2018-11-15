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
			DateTime? endDate,
			DateTime modifiedDate,
			int productID,
			decimal standardCost,
			DateTime startDate)
		{
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
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
	}
}

/*<Codenesium>
    <Hash>be876dee98419a44805efa58d703f077</Hash>
</Codenesium>*/