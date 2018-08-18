using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductListPriceHistoryRequestModelValidator : AbstractApiProductListPriceHistoryRequestModelValidator, IApiProductListPriceHistoryRequestModelValidator
	{
		public ApiProductListPriceHistoryRequestModelValidator(IProductListPriceHistoryRepository productListPriceHistoryRepository)
			: base(productListPriceHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			this.StartDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cb0a8ee57502ccec2ea517848e9aa564</Hash>
</Codenesium>*/