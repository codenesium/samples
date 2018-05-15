using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiStateProvinceModelValidator: AbstractValidator<ApiStateProvinceModel>
	{
		public new ValidationResult Validate(ApiStateProvinceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStateProvinceModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateProvinceRepository StateProvinceRepository { get; set; }
		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.CountryRegionCode != null).WithMessage("Violates unique constraint");
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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.StateProvinceCode != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).NotNull();
		}

		private bool BeUniqueGetName(ApiStateProvinceModel model)
		{
			return this.StateProvinceRepository.GetName(model.Name) != null;
		}

		private bool BeUniqueGetStateProvinceCodeCountryRegionCode(ApiStateProvinceModel model)
		{
			return this.StateProvinceRepository.GetStateProvinceCodeCountryRegionCode(model.StateProvinceCode,model.CountryRegionCode) != null;
		}
	}
}

/*<Codenesium>
    <Hash>0501e665191b6838b80a36a406802234</Hash>
</Codenesium>*/