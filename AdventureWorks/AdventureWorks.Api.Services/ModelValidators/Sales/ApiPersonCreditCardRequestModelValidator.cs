using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonCreditCardRequestModelValidator : AbstractApiPersonCreditCardRequestModelValidator, IApiPersonCreditCardRequestModelValidator
	{
		public ApiPersonCreditCardRequestModelValidator(IPersonCreditCardRepository personCreditCardRepository)
			: base(personCreditCardRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>44926d221d1c48864e3e0c14f12cc18a</Hash>
</Codenesium>*/