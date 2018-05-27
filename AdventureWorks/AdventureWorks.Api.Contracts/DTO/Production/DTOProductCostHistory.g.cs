using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductCostHistory: AbstractDTO
	{
		public DTOProductCostHistory() : base()
		{}

		public void SetProperties(int productID,
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

		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public decimal StandardCost { get; set; }
		public DateTime StartDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>cd1ecfeef241ddc4008f02d27b605f5b</Hash>
</Codenesium>*/