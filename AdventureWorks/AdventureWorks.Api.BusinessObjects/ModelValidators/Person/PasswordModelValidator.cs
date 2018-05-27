using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4c0a06a706702dc81ce75d069b5a888c</Hash>
</Codenesium>*/