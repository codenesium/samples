using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class BusinessEntityContactModelValidator: AbstractBusinessEntityContactModelValidator, IBusinessEntityContactModelValidator
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
    <Hash>ae6f21e0c545a38eaa1840d5486b5f61</Hash>
</Codenesium>*/