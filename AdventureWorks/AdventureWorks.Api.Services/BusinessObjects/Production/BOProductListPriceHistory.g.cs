using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>4fb875218957e6b131b14feaa4486f07</Hash>
</Codenesium>*/