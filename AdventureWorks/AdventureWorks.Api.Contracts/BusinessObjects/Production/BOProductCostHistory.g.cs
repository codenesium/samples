using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductCostHistory: AbstractBusinessObject
	{
		public BOProductCostHistory() : base()
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

		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public decimal StandardCost { get; private set; }
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>382f8a60afd2af72595bd44103f69df1</Hash>
</Codenesium>*/