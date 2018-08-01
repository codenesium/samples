using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductCostHistoryRequestModelValidator : AbstractApiProductCostHistoryRequestModelValidator, IApiProductCostHistoryRequestModelValidator
	{
		public ApiProductCostHistoryRequestModelValidator(IProductCostHistoryRepository productCostHistoryRepository)
			: base(productCostHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
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
    <Hash>2105267fb77c5f20119d47f8e10ccbe2</Hash>
</Codenesium>*/