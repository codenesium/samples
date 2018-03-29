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

		public void PatchMode()
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>55a13203c11c58038e0daa6738e17b6f</Hash>
</Codenesium>*/