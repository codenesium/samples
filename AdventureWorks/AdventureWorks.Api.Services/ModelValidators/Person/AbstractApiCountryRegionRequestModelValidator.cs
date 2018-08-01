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
	public abstract class AbstractApiCountryRegionRequestModelValidator : AbstractValidator<ApiCountryRegionRequestModel>
	{
		private string existingRecordId;

		private ICountryRegionRepository countryRegionRepository;

		public AbstractApiCountryRegionRequestModelValidator(ICountryRegionRepository countryRegionRepository)
		{
			this.countryRegionRepository = countryRegionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiCountryRegionRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>b3c470ea1b7b6a1b188abcb2720a6779</Hash>
</Codenesium>*/