using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractBreedModelValidator: AbstractValidator<BreedModel>
	{
		public new ValidationResult Validate(BreedModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BreedModel model)
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
			this.RuleFor(x => x.SpeciesId).Must(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
		}

		private bool BeValidSpecies(int id)
		{
			return this.SpeciesRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>185fd098117fef42d177363ee9f7b89b</Hash>
</Codenesium>*/