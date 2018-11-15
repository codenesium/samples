using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductPhotoServerRequestModelValidator : AbstractValidator<ApiProductPhotoServerRequestModel>
	{
		private int existingRecordId;

		private IProductPhotoRepository productPhotoRepository;

		public AbstractApiProductPhotoServerRequestModelValidator(IProductPhotoRepository productPhotoRepository)
		{
			this.productPhotoRepository = productPhotoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductPhotoServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void LargePhotoRules()
		{
		}

		public virtual void LargePhotoFileNameRules()
		{
			this.RuleFor(x => x.LargePhotoFileName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ThumbNailPhotoRules()
		{
		}

		public virtual void ThumbnailPhotoFileNameRules()
		{
			this.RuleFor(x => x.ThumbnailPhotoFileName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>3b3e1392d4ef5bb270559a2b4b1dbb2f</Hash>
</Codenesium>*/