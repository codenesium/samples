using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductPhotoModelValidator: AbstractValidator<ProductPhotoModel>
	{
		public new ValidationResult Validate(ProductPhotoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductPhotoModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ThumbNailPhotoRules()
		{                       }

		public virtual void ThumbnailPhotoFileNameRules()
		{
			this.RuleFor(x => x.ThumbnailPhotoFileName).Length(0, 50);
		}

		public virtual void LargePhotoRules()
		{                       }

		public virtual void LargePhotoFileNameRules()
		{
			this.RuleFor(x => x.LargePhotoFileName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>4e84fd4eccfd1250a68aa047f0e3f774</Hash>
</Codenesium>*/