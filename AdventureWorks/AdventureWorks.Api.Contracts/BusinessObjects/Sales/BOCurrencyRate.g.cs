using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOCurrencyRate: AbstractBusinessObject
	{
		public BOCurrencyRate() : base()
		{}

		public void SetProperties(int currencyRateID,
		                          decimal averageRate,
		                          DateTime currencyRateDate,
		                          decimal endOfDayRate,
		                          string fromCurrencyCode,
		                          DateTime modifiedDate,
		                          string toCurrencyCode)
		{
			this.AverageRate = averageRate.ToDecimal();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.CurrencyRateID = currencyRateID.ToInt();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ToCurrencyCode = toCurrencyCode;
		}

		public decimal AverageRate { get; private set; }
		public DateTime CurrencyRateDate { get; private set; }
		public int CurrencyRateID { get; private set; }
		public decimal EndOfDayRate { get; private set; }
		public string FromCurrencyCode { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string ToCurrencyCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1b19c6d5175616347111b637e7da48d2</Hash>
</Codenesium>*/