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
			this.ProductPhotoIDRules();
			this.PrimaryRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductProductPhotoModel model)
		{
			this.ProductPhotoIDRules();
			this.PrimaryRules();
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
    <Hash>c1f699f193fd766c6c8608bf2d9fda28</Hash>
</Codenesium>*/