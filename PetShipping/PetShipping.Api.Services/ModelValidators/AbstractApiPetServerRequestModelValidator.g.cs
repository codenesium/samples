using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreedByBreedId).When(x => !x?.BreedId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void ClientIdRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
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
    <Hash>b26f6d6ca5f3af712f40599586e9d199</Hash>
</Codenesium>*/