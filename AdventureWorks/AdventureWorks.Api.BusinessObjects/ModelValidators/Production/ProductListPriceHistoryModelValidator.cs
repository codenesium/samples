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
			this.StartDateRules();
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductListPriceHistoryModel model)
		{
			this.StartDateRules();
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a73b3473c10c7f72454b562852090c3c</Hash>
</Codenesium>*/