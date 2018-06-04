using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCreditCardRequestModelValidator: AbstractApiCreditCardRequestModelValidator, IApiCreditCardRequestModelValidator
	{
		public ApiCreditCardRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model)
		{
			this.CardNumberRules();
			this.CardTypeRules();
			this.ExpMonthRules();
			this.ExpYearRules();
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
    <Hash>1c8543d22ac408aba0ece6622c6531da</Hash>
</Codenesium>*/