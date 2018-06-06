using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPasswordRequestModelValidator: AbstractApiPasswordRequestModelValidator, IApiPasswordRequestModelValidator
	{
		public ApiPasswordRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a8c0dbbccd6349030e194c1ac494f9c9</Hash>
</Codenesium>*/