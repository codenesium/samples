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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>44e83411971a0ba549ba865c1c586dc3</Hash>
</Codenesium>*/