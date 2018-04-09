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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>db18f4d2b3d5475594959faa92ae377a</Hash>
</Codenesium>*/