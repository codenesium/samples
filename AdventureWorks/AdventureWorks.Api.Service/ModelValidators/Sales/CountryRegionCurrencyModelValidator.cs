using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class CountryRegionCurrencyModelValidator: AbstractCountryRegionCurrencyModelValidator, ICountryRegionCurrencyModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>32019ba507a35db1e4c886b4f02be272</Hash>
</Codenesium>*/