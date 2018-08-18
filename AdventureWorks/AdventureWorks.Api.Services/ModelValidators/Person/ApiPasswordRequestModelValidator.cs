using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPasswordRequestModelValidator : AbstractApiPasswordRequestModelValidator, IApiPasswordRequestModelValidator
	{
		public ApiPasswordRequestModelValidator(IPasswordRepository passwordRepository)
			: base(passwordRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model)
		{
			this.ModifiedDateRules();
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model)
		{
			this.ModifiedDateRules();
			this.PasswordHashRules();
			this.PasswordSaltRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3181536985afe4b857334d9a750acf17</Hash>
</Codenesium>*/