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
	public class ApiBreedServerRequestModelValidator : AbstractValidator<ApiBreedServerRequestModel>, IApiBreedServerRequestModelValidator
	{
		private int existingRecordId;

		protected IBreedRepository BreedRepository { get; private set; }

		public ApiBreedServerRequestModelValidator(IBreedRepository breedRepository)
		{
			this.BreedRepository = breedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBreedServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBreedServerRequestModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedServerRequestModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>3f486ed780a08e6578405dca4a034ab4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/