using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class EmailAddressModelValidator: AbstractEmailAddressModelValidator,IEmailAddressModelValidator
	{
		public EmailAddressModelValidator()
		{   }

		public void CreateMode()
		{
			this.EmailAddressIDRules();
			this.EmailAddress1Rules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.EmailAddressIDRules();
			this.EmailAddress1Rules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>9787a6cf6bbf82cce2f79f84cdaead34</Hash>
</Codenesium>*/