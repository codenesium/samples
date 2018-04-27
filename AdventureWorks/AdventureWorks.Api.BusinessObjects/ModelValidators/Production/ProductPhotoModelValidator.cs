using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductPhotoModelValidator: AbstractProductPhotoModelValidator, IProductPhotoModelValidator
	{
		public ProductPhotoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductPhotoModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductPhotoModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d9693707ab02dad545d7774f32be7d14</Hash>
</Codenesium>*/