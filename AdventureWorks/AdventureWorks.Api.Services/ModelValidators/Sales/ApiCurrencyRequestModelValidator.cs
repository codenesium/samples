using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCurrencyRequestModelValidator: AbstractApiCurrencyRequestModelValidator, IApiCurrencyRequestModelValidator
	{
		public ApiCurrencyRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>61bd5049f718b1dc701238572f1373b9</Hash>
</Codenesium>*/