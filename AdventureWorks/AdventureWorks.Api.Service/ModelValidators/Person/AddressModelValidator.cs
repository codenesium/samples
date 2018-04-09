using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class AddressModelValidator: AbstractAddressModelValidator,IAddressModelValidator
	{
		public AddressModelValidator()
		{   }

		public void CreateMode()
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.StateProvinceIDRules();
			this.PostalCodeRules();
			this.SpatialLocationRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.StateProvinceIDRules();
			this.PostalCodeRules();
			this.SpatialLocationRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>96f7adb746953fc96a54cebd1390c99f</Hash>
</Codenesium>*/