using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductPhotoModelValidator: AbstractValidator<ApiProductPhotoModel>
	{
		public new ValidationResult Validate(ApiProductPhotoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductPhotoModel model)
		{
			return await base.ValidateAsync(model);
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

		public virtual void ThumbNailPhotoRules()
		{                       }

		public virtual void ThumbnailPhotoFileNameRules()
		{
			this.RuleFor(x => x.ThumbnailPhotoFileName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>25a9f9f1bf6855cd8c7281b2e76f1495</Hash>
</Codenesium>*/