using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPetServerRequestModelValidator : AbstractValidator<ApiPetServerRequestModel>
	{
		private int existingRecordId;

		private IPetRepository petRepository;

		public AbstractApiPetServerRequestModelValidator(IPetRepository petRepository)
		{
			this.petRepository = petRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AcquiredDateRules()
		{
		}

		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreedByBreedId).When(x => !x?.BreedId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void PenIdRules()
		{
			this.RuleFor(x => x.PenId).MustAsync(this.BeValidPenByPenId).When(x => !x?.PenId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void PriceRules()
		{
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpeciesBySpeciesId).When(x => !x?.SpeciesId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidBreedByBreedId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.petRepository.BreedByBreedId(id);

			return record != null;
		}

		private async Task<bool> BeValidPenByPenId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.petRepository.PenByPenId(id);

			return record != null;
		}

		private async Task<bool> BeValidSpeciesBySpeciesId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.petRepository.SpeciesBySpeciesId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>815b2a0a8200281cf082154ea19a6a62</Hash>
</Codenesium>*/