using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiStateProvinceRequestModelValidator: AbstractValidator<ApiStateProvinceRequestModel>
	{
		public new ValidationResult Validate(ApiStateProvinceRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStateProvinceRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateProvinceRepository StateProvinceRepository { get; set; }
		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.CountryRegionCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.CountryRegionCode));
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
			this.RuleFor(x => x.IsOnlyStateProvinceFlag).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.StateProvinceCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.StateProvinceCode));
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).NotNull();
		}

		private async Task<bool> BeUniqueGetName(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.StateProvinceRepository.GetName(model.Name);

			return record == null;
		}
		private async Task<bool> BeUniqueGetStateProvinceCodeCountryRegionCode(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.StateProvinceRepository.GetStateProvinceCodeCountryRegionCode(model.StateProvinceCode,model.CountryRegionCode);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>14dfec01c38d9c6479679fc8913bbc93</Hash>
</Codenesium>*/