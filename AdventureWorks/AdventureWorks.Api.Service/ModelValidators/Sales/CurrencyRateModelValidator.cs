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

		public void PatchMode()
		{
			this.CurrencyRateDateRules();
			this.FromCurrencyCodeRules();
			this.ToCurrencyCodeRules();
			this.AverageRateRules();
			this.EndOfDayRateRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>0857dcf194d7944f5ead04480c8e0bef</Hash>
</Codenesium>*/