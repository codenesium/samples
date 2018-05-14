using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPasswordModelValidator: AbstractApiPasswordModelValidator, IApiPasswordModelValidator
	{
		public ApiPasswordModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPasswordModel model)
		{
			this.ModifiedDateRules();
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordModel model)
		{
			this.ModifiedDateRules();
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d1efc764905907829936a106ebbd34d4</Hash>
</Codenesium>*/