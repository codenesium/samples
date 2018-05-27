using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductListPriceHistory: AbstractDTO
	{
		public DTOProductListPriceHistory() : base()
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

		public Nullable<DateTime> EndDate { get; set; }
		public decimal ListPrice { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public DateTime StartDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>b48d6cf218b190a1cf4cc2bffd881fad</Hash>
</Codenesium>*/