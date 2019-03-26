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
	public abstract class AbstractApiSpaceSpaceFeatureServerRequestModelValidator : AbstractValidator<ApiSpaceSpaceFeatureServerRequestModel>
	{
		private int existingRecordId;

		protected ISpaceSpaceFeatureRepository SpaceSpaceFeatureRepository { get; private set; }

		public AbstractApiSpaceSpaceFeatureServerRequestModelValidator(ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository)
		{
			this.SpaceSpaceFeatureRepository = spaceSpaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceSpaceFeatureServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SpaceFeatureIdRules()
		{
			this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeatureBySpaceFeatureId).When(x => !x?.SpaceFeatureId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SpaceIdRules()
		{
			this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpaceBySpaceId).When(x => !x?.SpaceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSpaceFeatureBySpaceFeatureId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceSpaceFeatureRepository.SpaceFeatureBySpaceFeatureId(id);

			return record != null;
		}

		protected async Task<bool> BeValidSpaceBySpaceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpaceSpaceFeatureRepository.SpaceBySpaceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>941635366fe93999b07d464614633dd8</Hash>
</Codenesium>*/