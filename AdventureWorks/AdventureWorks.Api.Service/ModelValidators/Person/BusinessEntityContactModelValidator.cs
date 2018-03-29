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

		public void PatchMode()
		{
			this.PersonIDRules();
			this.ContactTypeIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b43c5e3f335c2e71b04acf9a9bddbe8e</Hash>
</Codenesium>*/