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

		public void PatchMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>8210c3a049eeb81339e42c9026f3874d</Hash>
</Codenesium>*/