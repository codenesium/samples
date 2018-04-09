using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CurrencyRateModelValidator: AbstractCurrencyRateModelValidator,ICurrencyRateModelValidator
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
    <Hash>287754587aae943f98f5fc096930e82f</Hash>
</Codenesium>*/