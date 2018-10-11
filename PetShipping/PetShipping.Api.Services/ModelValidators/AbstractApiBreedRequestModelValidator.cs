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
	public abstract class AbstractApiBreedRequestModelValidator : AbstractValidator<ApiBreedRequestModel>
	{
		private int existingRecordId;

		private IBreedRepository breedRepository;

		public AbstractApiBreedRequestModelValidator(IBreedRepository breedRepository)
		{
			this.breedRepository = breedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void SpeciesIdRules()
		{
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpeciesBySpeciesId).When(x => x?.SpeciesId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpeciesBySpeciesId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.breedRepository.SpeciesBySpeciesId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>40e5444d1645142ae4c1c1c900c5f6f0</Hash>
</Codenesium>*/