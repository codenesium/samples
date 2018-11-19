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

		private ICountryRequirementRepository countryRequirementRepository;

		public AbstractApiCountryRequirementServerRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
		{
			this.countryRequirementRepository = countryRequirementRepository;
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

		private async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.countryRequirementRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>bde18776012508a7ce6877426d0d939d</Hash>
</Codenesium>*/