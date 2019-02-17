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
	public abstract class AbstractApiBreedServerRequestModelValidator : AbstractValidator<ApiBreedServerRequestModel>
	{
		private int existingRecordId;

		protected IBreedRepository BreedRepository { get; private set; }

		public AbstractApiBreedServerRequestModelValidator(IBreedRepository breedRepository)
		{
			this.BreedRepository = breedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpeciesBySpeciesId).When(x => !x?.SpeciesId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSpeciesBySpeciesId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BreedRepository.SpeciesBySpeciesId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b47b4eda3581ef73a1ee22ad0e09e9ef</Hash>
</Codenesium>*/