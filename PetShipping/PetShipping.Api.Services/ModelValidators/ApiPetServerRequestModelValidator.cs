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
	public class ApiPetServerRequestModelValidator : AbstractValidator<ApiPetServerRequestModel>, IApiPetServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPetRepository PetRepository { get; private set; }

		public ApiPetServerRequestModelValidator(IPetRepository petRepository)
		{
			this.PetRepository = petRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetServerRequestModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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

		protected async Task<bool> BeValidBreedByBreedId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PetRepository.BreedByBreedId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>5e130b9cdf86c002dd71ad389e0aefa6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/