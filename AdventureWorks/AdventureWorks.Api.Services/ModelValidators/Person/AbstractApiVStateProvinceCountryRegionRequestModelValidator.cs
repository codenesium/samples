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
	public abstract class AbstractApiVStateProvinceCountryRegionRequestModelValidator : AbstractValidator<ApiVStateProvinceCountryRegionRequestModel>
	{
		private int existingRecordId;

		private IVStateProvinceCountryRegionRepository vStateProvinceCountryRegionRepository;

		public AbstractApiVStateProvinceCountryRegionRequestModelValidator(IVStateProvinceCountryRegionRepository vStateProvinceCountryRegionRepository)
		{
			this.vStateProvinceCountryRegionRepository = vStateProvinceCountryRegionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVStateProvinceCountryRegionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void CountryRegionNameRules()
		{
			this.RuleFor(x => x.CountryRegionName).NotNull();
			this.RuleFor(x => x.CountryRegionName).Length(0, 50);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
		}

		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull();
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
		}

		public virtual void StateProvinceNameRules()
		{
			this.RuleFor(x => x.StateProvinceName).NotNull();
			this.RuleFor(x => x.StateProvinceName).Length(0, 50);
		}

		public virtual void TerritoryIDRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>bb5f03e0fd434cd1e694ae879f7a4b57</Hash>
</Codenesium>*/