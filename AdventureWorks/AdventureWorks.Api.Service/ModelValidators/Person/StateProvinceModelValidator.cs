using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class StateProvinceModelValidator: AbstractStateProvinceModelValidator,IStateProvinceModelValidator
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

		public void PatchMode()
		{
			this.StateProvinceCodeRules();
			this.CountryRegionCodeRules();
			this.IsOnlyStateProvinceFlagRules();
			this.NameRules();
			this.TerritoryIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>5207122bbdfe373d1d6a27aa4ce2a218</Hash>
</Codenesium>*/