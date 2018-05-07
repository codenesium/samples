using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractSpaceXSpaceFeatureModelValidator: AbstractValidator<SpaceXSpaceFeatureModel>
	{
		public new ValidationResult Validate(SpaceXSpaceFeatureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SpaceXSpaceFeatureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpaceFeatureRepository SpaceFeatureRepository { get; set; }
		public ISpaceRepository SpaceRepository { get; set; }
		public virtual void SpaceFeatureIdRules()
		{
			this.RuleFor(x => x.SpaceFeatureId).NotNull();
			this.RuleFor(x => x.SpaceFeatureId).Must(this.BeValidSpaceFeature).When(x => x ?.SpaceFeatureId != null).WithMessage("Invalid reference");
		}

		public virtual void SpaceIdRules()
		{
			this.RuleFor(x => x.SpaceId).NotNull();
			this.RuleFor(x => x.SpaceId).Must(this.BeValidSpace).When(x => x ?.SpaceId != null).WithMessage("Invalid reference");
		}

		private bool BeValidSpaceFeature(int id)
		{
			return this.SpaceFeatureRepository.Get(id) != null;
		}

		private bool BeValidSpace(int id)
		{
			return this.SpaceRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>125545cbae5ee82cbf04d253b3c66101</Hash>
</Codenesium>*/