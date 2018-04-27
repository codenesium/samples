using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductListPriceHistoryModelValidator: AbstractProductListPriceHistoryModelValidator, IProductListPriceHistoryModelValidator
	{
		public ProductListPriceHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductListPriceHistoryModel model)
		{
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductListPriceHistoryModel model)
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
    <Hash>0c905fe5a295b9c1ef84137b62024fe4</Hash>
</Codenesium>*/