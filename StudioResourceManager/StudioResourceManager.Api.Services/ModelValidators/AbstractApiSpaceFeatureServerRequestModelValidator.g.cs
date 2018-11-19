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
	public abstract class AbstractApiSpaceFeatureServerRequestModelValidator : AbstractValidator<ApiSpaceFeatureServerRequestModel>
	{
		private int existingRecordId;

		private ISpaceFeatureRepository spaceFeatureRepository;

		public AbstractApiSpaceFeatureServerRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
		{
			this.spaceFeatureRepository = spaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceFeatureServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>041938f3bf54a9a1c196fa777b32a176</Hash>
</Codenesium>*/