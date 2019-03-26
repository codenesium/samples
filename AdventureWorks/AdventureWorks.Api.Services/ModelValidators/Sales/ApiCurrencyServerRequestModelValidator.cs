using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCurrencyServerRequestModelValidator : AbstractApiCurrencyServerRequestModelValidator, IApiCurrencyServerRequestModelValidator
	{
		public ApiCurrencyServerRequestModelValidator(ICurrencyRepository currencyRepository)
			: base(currencyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCurrencyServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f97f4cc36eb426956bfa7b168a8e41d8</Hash>
</Codenesium>*/