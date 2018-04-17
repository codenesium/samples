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
			this.ProductDescriptionIDRules();
			this.CultureIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelProductDescriptionCultureModel model)
		{
			this.ProductDescriptionIDRules();
			this.CultureIDRules();
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
    <Hash>82552f0fa7111160204762bc7a0c2b44</Hash>
</Codenesium>*/