using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiProductPhotoRequestModelValidator: AbstractValidator<ApiProductPhotoRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiProductPhotoRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductPhotoRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>5819d68fabcdc071681231c77c8e7208</Hash>
</Codenesium>*/