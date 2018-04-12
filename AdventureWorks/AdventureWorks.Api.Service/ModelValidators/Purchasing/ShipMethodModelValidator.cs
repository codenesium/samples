using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ShipMethodModelValidator: AbstractShipMethodModelValidator, IShipMethodModelValidator
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
    <Hash>f6b6068e52ef0d2ad4c4bafd47e19e02</Hash>
</Codenesium>*/