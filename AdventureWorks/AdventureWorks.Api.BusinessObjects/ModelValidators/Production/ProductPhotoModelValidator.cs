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
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductPhotoModel model)
		{
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
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
    <Hash>509258b29681dc803df812514d7a9e34</Hash>
</Codenesium>*/