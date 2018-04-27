using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductModelProductDescriptionCultureModelValidator: AbstractProductModelProductDescriptionCultureModelValidator, IProductModelProductDescriptionCultureModelValidator
	{
		public ProductModelProductDescriptionCultureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductModelProductDescriptionCultureModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelProductDescriptionCultureModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ce0e339aeb7f8a0d80bc9cb5f5644ac0</Hash>
</Codenesium>*/