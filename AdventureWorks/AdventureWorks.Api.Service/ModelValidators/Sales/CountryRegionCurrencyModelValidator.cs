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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>a2ff3fff874aa32a1cfb61e20dc8e306</Hash>
</Codenesium>*/