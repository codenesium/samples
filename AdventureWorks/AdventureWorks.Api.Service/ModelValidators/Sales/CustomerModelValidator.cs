using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CustomerModelValidator: AbstractCustomerModelValidator,ICustomerModelValidator
	{
		public CustomerModelValidator()
		{   }

		public void CreateMode()
		{
			this.PersonIDRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			this.AccountNumberRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.PersonIDRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			this.AccountNumberRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.PersonIDRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			this.AccountNumberRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>f002516c0a6677fa5bf04bec3c4d6975</Hash>
</Codenesium>*/