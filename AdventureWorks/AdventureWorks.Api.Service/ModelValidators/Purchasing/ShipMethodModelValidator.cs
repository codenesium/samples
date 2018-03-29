using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ShipMethodModelValidator: AbstractShipMethodModelValidator,IShipMethodModelValidator
	{
		public ShipMethodModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>6365a73383326613c66711d4c4466d91</Hash>
</Codenesium>*/