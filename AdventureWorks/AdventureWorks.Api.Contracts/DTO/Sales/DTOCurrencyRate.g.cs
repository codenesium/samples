using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCurrencyRate: AbstractDTO
	{
		public DTOCurrencyRate() : base()
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

		public decimal AverageRate { get; set; }
		public DateTime CurrencyRateDate { get; set; }
		public int CurrencyRateID { get; set; }
		public decimal EndOfDayRate { get; set; }
		public string FromCurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ToCurrencyCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>6b69a6d329b9ac797b7abec510d540e1</Hash>
</Codenesium>*/