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
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.ModifiedDateRules();
			this.NameRules();
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
    <Hash>cab61606c16a7a201f9b9bfe9ffb1dfe</Hash>
</Codenesium>*/