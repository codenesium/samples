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
    <Hash>dd1b4c753349123feb406cb0627ee52b</Hash>
</Codenesium>*/