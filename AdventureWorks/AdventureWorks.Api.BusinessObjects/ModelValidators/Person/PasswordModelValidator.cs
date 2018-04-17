using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PasswordModelValidator: AbstractPasswordModelValidator, IPasswordModelValidator
	{
		public PasswordModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PasswordModel model)
		{
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PasswordModel model)
		{
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>48500fb80b4dc7b068ab23b90b1dc023</Hash>
</Codenesium>*/