using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiSpaceFeatureServerRequestModelValidator : AbstractValidator<ApiSpaceFeatureServerRequestModel>
	{
		private int existingRecordId;

		protected ISpaceFeatureRepository SpaceFeatureRepository { get; private set; }

		public AbstractApiSpaceFeatureServerRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
		{
			this.SpaceFeatureRepository = spaceFeatureRepository;
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
    <Hash>f58234ed3b0bd27b2b5447bc11508b8d</Hash>
</Codenesium>*/