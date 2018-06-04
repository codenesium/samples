using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonCreditCardRequestModelValidator: AbstractApiPersonCreditCardRequestModelValidator, IApiPersonCreditCardRequestModelValidator
	{
		public ApiPersonCreditCardRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model)
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model)
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7bf5b3a4381cbe81f85c07f822e2733b</Hash>
</Codenesium>*/