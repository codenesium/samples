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
	public abstract class AbstractApiPetServerRequestModelValidator : AbstractValidator<ApiPetServerRequestModel>
	{
		private int existingRecordId;

		protected IPetRepository PetRepository { get; private set; }

		public AbstractApiPetServerRequestModelValidator(IPetRepository petRepository)
		{
			this.PetRepository = petRepository;
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
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreedByBreedId).When(x => !x?.BreedId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PenIdRules()
		{
			this.RuleFor(x => x.PenId).MustAsync(this.BeValidPenByPenId).When(x => !x?.PenId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PriceRules()
		{
		}

		protected async Task<bool> BeValidBreedByBreedId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PetRepository.BreedByBreedId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPenByPenId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PetRepository.PenByPenId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>512bbba2182b2c71aaae122bb7a0ff63</Hash>
</Codenesium>*/