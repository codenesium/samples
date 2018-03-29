using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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
			RuleFor(x => x.ThumbnailPhotoFileName).Length(0,50);
		}

		public virtual void LargePhotoRules()
		{                       }

		public virtual void LargePhotoFileNameRules()
		{
			RuleFor(x => x.LargePhotoFileName).Length(0,50);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>2403d07079c575de23125e2db969078c</Hash>
</Codenesium>*/