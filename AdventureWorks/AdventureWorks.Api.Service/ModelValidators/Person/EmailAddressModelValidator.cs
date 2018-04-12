using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class EmailAddressModelValidator: AbstractEmailAddressModelValidator, IEmailAddressModelValidator
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
    <Hash>11b11e6cf0ce66fb47ea10dfc1ef32e2</Hash>
</Codenesium>*/