using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects

{
	public abstract class AbstractPetModelValidator: AbstractValidator<PetModel>
	{
		public new ValidationResult Validate(PetModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PetModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBreedRepository BreedRepository { get; set; }
		public IPenRepository PenRepository { get; set; }
		public ISpeciesRepository SpeciesRepository { get; set; }
		public virtual void AcquiredDateRules()
		{
			this.RuleFor(x => x.AcquiredDate).NotNull();
		}

		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).NotNull();
			this.RuleFor(x => x.BreedId).Must(this.BeValidBreed).When(x => x ?.BreedId != null).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void PenIdRules()
		{
			this.RuleFor(x => x.PenId).NotNull();
			this.RuleFor(x => x.PenId).Must(this.BeValidPen).When(x => x ?.PenId != null).WithMessage("Invalid reference");
		}

		public virtual void PriceRules()
		{
			this.RuleFor(x => x.Price).NotNull();
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).NotNull();
			this.RuleFor(x => x.SpeciesId).Must(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
		}

		private bool BeValidBreed(int id)
		{
			return this.BreedRepository.Get(id) != null;
		}

		private bool BeValidPen(int id)
		{
			return this.PenRepository.Get(id) != null;
		}

		private bool BeValidSpecies(int id)
		{
			return this.SpeciesRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>91ec76aa1cf7ee899aff149aa5b348cb</Hash>
</Codenesium>*/