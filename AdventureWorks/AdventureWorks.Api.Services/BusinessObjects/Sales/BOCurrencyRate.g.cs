using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>d51ded8c1153306ed818c98c8021469d</Hash>
</Codenesium>*/