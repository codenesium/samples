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
	public class ApiVideoServerRequestModelValidator : AbstractValidator<ApiVideoServerRequestModel>, IApiVideoServerRequestModelValidator
	{
		private int existingRecordId;

		protected IVideoRepository VideoRepository { get; private set; }

		public ApiVideoServerRequestModelValidator(IVideoRepository videoRepository)
		{
			this.VideoRepository = videoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVideoServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVideoServerRequestModel model)
		{
			this.DescriptionRules();
			this.TitleRules();
			this.UrlRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVideoServerRequestModel model)
		{
			this.DescriptionRules();
			this.TitleRules();
			this.UrlRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>1e2bdba904169f4f8275a2f242c951d6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/