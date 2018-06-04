using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductListPriceHistoryRequestModelValidator: AbstractApiProductListPriceHistoryRequestModelValidator, IApiProductListPriceHistoryRequestModelValidator
	{
		public ApiProductListPriceHistoryRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ab7f535f81727ebbf5d3330a42c71d48</Hash>
</Codenesium>*/