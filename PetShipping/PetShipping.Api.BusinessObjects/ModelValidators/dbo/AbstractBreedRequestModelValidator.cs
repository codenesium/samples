using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiBreedRequestModelValidator: AbstractValidator<ApiBreedRequestModel>
	{
		public new ValidationResult Validate(ApiBreedRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpeciesRepository SpeciesRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).NotNull();
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpecies(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SpeciesRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c957cad8d97f128e5ee5440ca6c06637</Hash>
</Codenesium>*/