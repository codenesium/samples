using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOEmployeePayHistory: AbstractDTO
	{
		public DTOEmployeePayHistory() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime modifiedDate,
		                          int payFrequency,
		                          decimal rate,
		                          DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
		}

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int PayFrequency { get; set; }
		public decimal Rate { get; set; }
		public DateTime RateChangeDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>7c3626e36d4b0f3cde2a482996dcbd1f</Hash>
</Codenesium>*/