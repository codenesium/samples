using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PasswordModelValidator: AbstractPasswordModelValidator, IPasswordModelValidator
	{
		public PasswordModelValidator()
		{   }

		public void CreateMode()
		{
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>3b2a8155c9a20f02e0bbe77922d796c0</Hash>
</Codenesium>*/