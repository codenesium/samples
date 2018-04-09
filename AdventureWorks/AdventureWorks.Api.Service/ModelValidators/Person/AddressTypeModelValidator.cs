using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class AddressTypeModelValidator: AbstractAddressTypeModelValidator,IAddressTypeModelValidator
	{
		public AddressTypeModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1433ed16bb54dae8fb714f5f5d53d7c9</Hash>
</Codenesium>*/