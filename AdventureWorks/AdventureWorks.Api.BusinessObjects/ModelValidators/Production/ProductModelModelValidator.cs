using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductModelModelValidator: AbstractProductModelModelValidator, IProductModelModelValidator
	{
		public ProductModelModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductModelModel model)
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelModel model)
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
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
    <Hash>770d8b37d7db2b1f81af260c2605d19c</Hash>
</Codenesium>*/