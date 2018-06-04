using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductListPriceHistory: AbstractBusinessObject
	{
		public BOProductListPriceHistory() : base()
		{}

		public void SetProperties(int productID,
		                          Nullable<DateTime> endDate,
		                          decimal listPrice,
		                          DateTime modifiedDate,
		                          DateTime startDate)
		{
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.StartDate = startDate.ToDateTime();
		}

		public Nullable<DateTime> EndDate { get; private set; }
		public decimal ListPrice { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>33ce545105581a06fdef1548ecd5277c</Hash>
</Codenesium>*/