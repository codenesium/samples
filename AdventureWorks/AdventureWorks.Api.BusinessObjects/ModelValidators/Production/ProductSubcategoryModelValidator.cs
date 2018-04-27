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
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductSubcategoryModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c6ab9b3a201407094a32acca89c885a3</Hash>
</Codenesium>*/