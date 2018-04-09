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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>fb55631d165bbfbb816692338068b034</Hash>
</Codenesium>*/