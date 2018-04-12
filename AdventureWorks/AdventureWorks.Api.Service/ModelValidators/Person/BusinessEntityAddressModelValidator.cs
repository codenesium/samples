using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityAddressModelValidator: AbstractBusinessEntityAddressModelValidator, IBusinessEntityAddressModelValidator
	{
		public BusinessEntityAddressModelValidator()
		{   }

		public void CreateMode()
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>b67e56e14085f0b5c025b5920b76e639</Hash>
</Codenesium>*/