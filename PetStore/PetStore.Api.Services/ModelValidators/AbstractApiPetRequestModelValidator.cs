using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPetRequestModelValidator : AbstractValidator<ApiPetRequestModel>
	{
		private int existingRecordId;

		private IPetRepository petRepository;

		public AbstractApiPetRequestModelValidator(IPetRepository petRepository)
		{
			this.petRepository = petRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AcquiredDateRules()
		{
		}

		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreedByBreedId).When(x => x?.BreedId != null).WithMessage("Invalid reference");
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void PenIdRules()
		{
			this.RuleFor(x => x.PenId).MustAsync(this.BeValidPenByPenId).When(x => x?.PenId != null).WithMessage("Invalid reference");
		}

		public virtual void PriceRules()
		{
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpeciesBySpeciesId).When(x => x?.SpeciesId != null).WithMessage("Invalid reference");
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
    <Hash>a5a5b9433d80e4a3e6fabb9693a50d6c</Hash>
</Codenesium>*/