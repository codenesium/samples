using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityAddressModelValidator: AbstractBusinessEntityAddressModelValidator,IBusinessEntityAddressModelValidator
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
    <Hash>446a5e033435433aa8713b5e135e21fb</Hash>
</Codenesium>*/