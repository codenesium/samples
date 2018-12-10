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
	}
}

/*<Codenesium>
    <Hash>b92fbc6fbacfbefc3ecd41c7645ef4e9</Hash>
</Codenesium>*/