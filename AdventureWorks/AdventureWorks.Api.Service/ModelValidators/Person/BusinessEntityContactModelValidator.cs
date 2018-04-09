using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityContactModelValidator: AbstractBusinessEntityContactModelValidator,IBusinessEntityContactModelValidator
	{
		public BusinessEntityContactModelValidator()
		{   }

		public void CreateMode()
		{
			this.PersonIDRules();
			this.ContactTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.PersonIDRules();
			this.ContactTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>5711a1536563b18de1be32678e9d4991</Hash>
</Codenesium>*/