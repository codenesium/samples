using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductDescriptionModelValidator: AbstractProductDescriptionModelValidator, IProductDescriptionModelValidator
	{
		public ProductDescriptionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductDescriptionModel model)
		{
			this.DescriptionRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductDescriptionModel model)
		{
			this.DescriptionRules();
			this.ModifiedDateRules();
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
    <Hash>a0f0b7ad17e5e3d9e7809fc147b28297</Hash>
</Codenesium>*/