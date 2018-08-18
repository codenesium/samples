using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCurrencyRequestModelValidator : AbstractApiCurrencyRequestModelValidator, IApiCurrencyRequestModelValidator
	{
		public ApiCurrencyRequestModelValidator(ICurrencyRepository currencyRepository)
			: base(currencyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model)
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
    <Hash>f2dd4a85f25b0a35712c9aa6cb53f635</Hash>
</Codenesium>*/