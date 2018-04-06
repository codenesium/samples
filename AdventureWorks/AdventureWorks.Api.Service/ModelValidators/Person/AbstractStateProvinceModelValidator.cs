using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public ICountryRegionRepository CountryRegionRepository {get; set;}
		public ISalesTerritoryRepository SalesTerritoryRepository {get; set;}
		public virtual void StateProvinceCodeRules()
		{
			RuleFor(x => x.StateProvinceCode).NotNull();
			RuleFor(x => x.StateProvinceCode).Length(0,3);
		}

		public virtual void CountryRegionCodeRules()
		{
			RuleFor(x => x.CountryRegionCode).NotNull();
			RuleFor(x => x.CountryRegionCode).Must(BeValidCountryRegion).When(x => x ?.CountryRegionCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.CountryRegionCode).Length(0,3);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
			RuleFor(x => x.IsOnlyStateProvinceFlag).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).NotNull();
			RuleFor(x => x.TerritoryID).Must(BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidCountryRegion(string id)
		{
			Response response = new Response();

			this.CountryRegionRepository.GetById(id,response);
			return response.CountryRegions.Count > 0;
		}

		public bool BeValidSalesTerritory(int id)
		{
			Response response = new Response();

			this.SalesTerritoryRepository.GetById(id,response);
			return response.SalesTerritories.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>eb661255a6edc79605ae8facd7599fb9</Hash>
</Codenesium>*/