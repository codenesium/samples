using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductProductPhotoModelValidator: AbstractProductProductPhotoModelValidator, IProductProductPhotoModelValidator
	{
		public ProductProductPhotoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductProductPhotoModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductProductPhotoModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>39725fa2be5f4772089b9ba908c08f1e</Hash>
</Codenesium>*/