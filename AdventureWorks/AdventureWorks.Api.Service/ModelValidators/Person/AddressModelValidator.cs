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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>923f27e5690542db80d3e25a9449aa7a</Hash>
</Codenesium>*/