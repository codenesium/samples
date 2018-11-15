using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiBreedServerRequestModelValidator : AbstractValidator<ApiBreedServerRequestModel>
	{
		private int existingRecordId;

		private IBreedRepository breedRepository;

		public AbstractApiBreedServerRequestModelValidator(IBreedRepository breedRepository)
		{
			this.breedRepository = breedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedServerRequestModel model, int id)
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
			this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpeciesBySpeciesId).When(x => !x?.SpeciesId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSpeciesBySpeciesId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.breedRepository.SpeciesBySpeciesId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8a5adba1023b24c3442444c745efb062</Hash>
</Codenesium>*/