using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductSubcategoryModelValidator: AbstractProductSubcategoryModelValidator, IProductSubcategoryModelValidator
	{
		public ProductSubcategoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductSubcategoryModel model)
		{
			this.ProductCategoryIDRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductSubcategoryModel model)
		{
			this.ProductCategoryIDRules();
			this.NameRules();
			this.RowguidRules();
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
    <Hash>03712a4a88c0c7bf34c40b388f1a4b24</Hash>
</Codenesium>*/