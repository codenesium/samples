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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
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
    <Hash>9d6aa52947be16e37178b8c1a400529e</Hash>
</Codenesium>*/