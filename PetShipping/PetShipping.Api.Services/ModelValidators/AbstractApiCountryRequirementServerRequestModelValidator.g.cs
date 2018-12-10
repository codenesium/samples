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
	public abstract class AbstractApiCountryRequirementServerRequestModelValidator : AbstractValidator<ApiCountryRequirementServerRequestModel>
	{
		private int existingRecordId;

		protected ICountryRequirementRepository CountryRequirementRepository { get; private set; }

		public AbstractApiCountryRequirementServerRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
		{
			this.CountryRequirementRepository = countryRequirementRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRequirementServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DetailRules()
		{
			this.RuleFor(x => x.Detail).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Detail).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CountryRequirementRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6a6e9ee9b590474e7c5ecca67d72490b</Hash>
</Codenesium>*/