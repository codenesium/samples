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
			this.RuleFor(x => x.SpaceFeatureId).MustAsync(this.BeValidSpaceFeatureBySpaceFeatureId).When(x => x?.SpaceFeatureId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpaceFeatureBySpaceFeatureId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.spaceSpaceFeatureRepository.SpaceFeatureBySpaceFeatureId(id);

			return record != null;
		}

		private async Task<bool> BeValidSpaceBySpaceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.spaceSpaceFeatureRepository.SpaceBySpaceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f86f29df179b2c7d46c2d0a8fd4dba88</Hash>
</Codenesium>*/