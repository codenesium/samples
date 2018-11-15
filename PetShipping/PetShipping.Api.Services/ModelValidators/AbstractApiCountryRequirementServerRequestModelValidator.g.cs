using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void DetailRules()
		{
			this.RuleFor(x => x.Detail).NotNull();
			this.RuleFor(x => x.Detail).Length(0, 2147483647);
		}

		private async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.countryRequirementRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>975efdb7ce61cb18f197f7a22b664baf</Hash>
</Codenesium>*/