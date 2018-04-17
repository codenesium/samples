using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductCategoryModelValidator: AbstractProductCategoryModelValidator, IProductCategoryModelValidator
	{
		public ProductCategoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductCategoryModel model)
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductCategoryModel model)
		{
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
    <Hash>e64765dfd5a292031b74854dcee6aba9</Hash>
</Codenesium>*/