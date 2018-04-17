using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractStateProvinceModelValidator: AbstractValidator<StateProvinceModel>
	{
		public new ValidationResult Validate(StateProvinceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StateProvinceModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRegionRepository CountryRegionRepository { get; set; }
		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull();
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x.CountryRegionCode).Must(this.BeValidCountryRegion).When(x => x ?.CountryRegionCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
			this.RuleFor(x => x.IsOnlyStateProvinceFlag).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).NotNull();
			this.RuleFor(x => x.TerritoryID).Must(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCountryRegion(string id)
		{
			return this.CountryRegionRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesTerritory(int id)
		{
			return this.SalesTerritoryRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>7e0efbe62d0b0bfbc4a262f10a92974e</Hash>
</Codenesium>*/