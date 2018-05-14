using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiBreedModelValidator: AbstractValidator<ApiBreedModel>
	{
		public new ValidationResult Validate(ApiBreedModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedModel model)
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
    <Hash>7e0e8aa8f13eb0ad3cb8a4ac210b8bff</Hash>
</Codenesium>*/