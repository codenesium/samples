using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CountryRegionCurrencyModelValidator: AbstractCountryRegionCurrencyModelValidator,ICountryRegionCurrencyModelValidator
	{
		public CountryRegionCurrencyModelValidator()
		{   }

		public void CreateMode()
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.CurrencyCodeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>db7ea897509a6b1de0784dfced566127</Hash>
</Codenesium>*/