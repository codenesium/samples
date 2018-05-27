using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9949e3c3ba075c9d4141b6f787b3af95</Hash>
</Codenesium>*/