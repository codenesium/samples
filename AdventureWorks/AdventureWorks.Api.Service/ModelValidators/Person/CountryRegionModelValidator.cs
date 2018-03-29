using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CountryRegionModelValidator: AbstractCountryRegionModelValidator,ICountryRegionModelValidator
	{
		public CountryRegionModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>3e2fa6d715bf4a4ab15ae9535ee26554</Hash>
</Codenesium>*/