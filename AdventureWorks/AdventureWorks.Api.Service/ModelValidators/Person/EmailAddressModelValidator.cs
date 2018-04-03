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
			this.EmailAddressRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.EmailAddressIDRules();
			this.EmailAddressRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.EmailAddressIDRules();
			this.EmailAddressRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b105ffca3ad44f6984b2618cefe0819c</Hash>
</Codenesium>*/