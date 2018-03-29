using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PasswordModelValidator: AbstractPasswordModelValidator,IPasswordModelValidator
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

		public void PatchMode()
		{
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>cdaf2c86224a4331b01749b26ae0d30a</Hash>
</Codenesium>*/