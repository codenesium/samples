using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCountryRegionServerRequestModelValidator : AbstractValidator<ApiCountryRegionServerRequestModel>
	{
		private string existingRecordId;

		private ICountryRegionRepository countryRegionRepository;

		public AbstractApiCountryRegionServerRequestModelValidator(ICountryRegionRepository countryRegionRepository)
		{
			this.countryRegionRepository = countryRegionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionServerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiCountryRegionServerRequestModel model,  CancellationToken cancellationToken)
		{
			CountryRegion record = await this.countryRegionRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.CountryRegionCode == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>086b6b8d50f9896bdfaa74913dd037a8</Hash>
</Codenesium>*/