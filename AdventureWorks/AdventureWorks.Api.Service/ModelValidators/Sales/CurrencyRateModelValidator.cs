using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class CurrencyRateModelValidator: AbstractCurrencyRateModelValidator, ICurrencyRateModelValidator
	{
		public CurrencyRateModelValidator()
		{   }

		public void CreateMode()
		{
			this.CurrencyRateDateRules();
			this.FromCurrencyCodeRules();
			this.ToCurrencyCodeRules();
			this.AverageRateRules();
			this.EndOfDayRateRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.CurrencyRateDateRules();
			this.FromCurrencyCodeRules();
			this.ToCurrencyCodeRules();
			this.AverageRateRules();
			this.EndOfDayRateRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>dd630ff69b66be04dc6f7b73e8f5d329</Hash>
</Codenesium>*/