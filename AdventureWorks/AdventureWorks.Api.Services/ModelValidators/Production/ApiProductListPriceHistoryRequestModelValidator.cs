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
    <Hash>cad41a26b3a4b080d7a4c6e0c01aecef</Hash>
</Codenesium>*/