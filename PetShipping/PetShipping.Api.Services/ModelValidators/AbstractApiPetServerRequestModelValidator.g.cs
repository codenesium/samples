using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreedByBreedId).When(x => !x?.BreedId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ClientIdRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WeightRules()
		{
		}

		private async Task<bool> BeValidBreedByBreedId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.petRepository.BreedByBreedId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>33329ac6fbbb99dc677c0a506dc2abb1</Hash>
</Codenesium>*/