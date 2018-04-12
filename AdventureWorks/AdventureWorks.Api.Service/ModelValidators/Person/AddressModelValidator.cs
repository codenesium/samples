using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class AddressModelValidator: AbstractAddressModelValidator, IAddressModelValidator
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
    <Hash>db26f02f721fe1c7aeff83b6e2c144b3</Hash>
</Codenesium>*/