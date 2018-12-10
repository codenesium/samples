using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiStudioServerRequestModelValidator : AbstractValidator<ApiStudioServerRequestModel>
	{
		private int existingRecordId;

		protected IStudioRepository StudioRepository { get; private set; }

		public AbstractApiStudioServerRequestModelValidator(IStudioRepository studioRepository)
		{
			this.StudioRepository = studioRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudioServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address1).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address2).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.City).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProvinceRules()
		{
			this.RuleFor(x => x.Province).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Province).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Website).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ZipRules()
		{
			this.RuleFor(x => x.Zip).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>3e62273120944df4b049c4691142acf5</Hash>
</Codenesium>*/