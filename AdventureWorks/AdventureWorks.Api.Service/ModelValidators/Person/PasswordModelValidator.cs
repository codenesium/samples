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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>0c738485a49d72b2f8c6a5553b26b668</Hash>
</Codenesium>*/