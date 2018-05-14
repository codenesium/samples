using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductListPriceHistoryModelValidator: AbstractApiProductListPriceHistoryModelValidator, IApiProductListPriceHistoryModelValidator
	{
		public ApiProductListPriceHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryModel model)
		{
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryModel model)
		{
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>dc3f4abdfc9ab3bd73603fe9238f6bd9</Hash>
</Codenesium>*/