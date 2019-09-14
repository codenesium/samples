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
	public class ApiCountryRequirementServerRequestModelValidator : AbstractValidator<ApiCountryRequirementServerRequestModel>, IApiCountryRequirementServerRequestModelValidator
	{
		private int existingRecordId;

		protected ICountryRequirementRepository CountryRequirementRepository { get; private set; }

		public ApiCountryRequirementServerRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
		{
			this.CountryRequirementRepository = countryRequirementRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRequirementServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementServerRequestModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementServerRequestModel model)
		{
			this.CountryIdRules();
			this.DetailsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DetailsRules()
		{
			this.RuleFor(x => x.Details).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Details).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CountryRequirementRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3b5f66eaee5e04e6e31a5c021dbbd224</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/