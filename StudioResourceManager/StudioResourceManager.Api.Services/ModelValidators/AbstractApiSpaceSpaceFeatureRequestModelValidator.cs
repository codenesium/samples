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
	public abstract class AbstractApiSpaceSpaceFeatureRequestModelValidator : AbstractValidator<ApiSpaceSpaceFeatureRequestModel>
	{
		private int existingRecordId;

		private ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository;

		public AbstractApiSpaceSpaceFeatureRequestModelValidator(ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository)
		{
			this.spaceSpaceFeatureRepository = spaceSpaceFeatureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpaceSpaceFeatureRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SpaceFeatureIdRules()
		{
			this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeature).When(x => x?.SpaceFeatureId != null).WithMessage("Invalid reference");
		}

		public virtual void SpaceIdRules()
		{
			this.RuleFor(x => x.SpaceId).MustAsync(this.BeValidSpace).When(x => x?.SpaceId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpaceFeature(int id,  CancellationToken cancellationToken)
		{
			var record = await this.spaceSpaceFeatureRepository.GetSpaceFeature(id);

			return record != null;
		}

		private async Task<bool> BeValidSpace(int id,  CancellationToken cancellationToken)
		{
			var record = await this.spaceSpaceFeatureRepository.GetSpace(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>e6b8dacdda108ddf8f8a150ee0bfb95a</Hash>
</Codenesium>*/