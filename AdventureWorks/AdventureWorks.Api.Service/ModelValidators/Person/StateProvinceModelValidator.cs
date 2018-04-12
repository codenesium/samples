using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class StateProvinceModelValidator: AbstractStateProvinceModelValidator, IStateProvinceModelValidator
	{
		public StateProvinceModelValidator()
		{   }

		public void CreateMode()
		{
			this.StateProvinceCodeRules();
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.NameRules();
			this.TerritoryIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.StateProvinceCodeRules();
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.NameRules();
			this.TerritoryIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>15f2306c710f5ad72c10e63310839506</Hash>
</Codenesium>*/