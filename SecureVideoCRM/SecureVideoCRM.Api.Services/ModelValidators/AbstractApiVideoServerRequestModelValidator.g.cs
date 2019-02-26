using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractApiVideoServerRequestModelValidator : AbstractValidator<ApiVideoServerRequestModel>
	{
		private int existingRecordId;

		protected IVideoRepository VideoRepository { get; private set; }

		public AbstractApiVideoServerRequestModelValidator(IVideoRepository videoRepository)
		{
			this.VideoRepository = videoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVideoServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 4000).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Title).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UrlRules()
		{
			this.RuleFor(x => x.Url).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Url).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>76d7d90781ee1eef71fb1796361fb911</Hash>
</Codenesium>*/