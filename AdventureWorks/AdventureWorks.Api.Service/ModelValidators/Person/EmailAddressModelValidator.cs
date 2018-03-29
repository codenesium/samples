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

		public void PatchMode()
		{
			this.EmailAddressIDRules();
			this.EmailAddress1Rules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>c7fc514ba33fed9ae46652c4e405edcb</Hash>
</Codenesium>*/