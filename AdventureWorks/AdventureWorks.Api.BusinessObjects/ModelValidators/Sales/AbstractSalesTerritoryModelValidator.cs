using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesTerritoryModelValidator: AbstractValidator<ApiSalesTerritoryModel>
	{
		public new ValidationResult Validate(ApiSalesTerritoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public virtual void CostLastYearRules()
		{
			this.RuleFor(x => x.CostLastYear).NotNull();
		}

		public virtual void CostYTDRules()
		{
			this.RuleFor(x => x.CostYTD).NotNull();
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void @GroupRules()
		{
			this.RuleFor(x => x.@Group).NotNull();
			this.RuleFor(x => x.@Group).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesLastYearRules()
		{
			this.RuleFor(x => x.SalesLastYear).NotNull();
		}

		public virtual void SalesYTDRules()
		{
			this.RuleFor(x => x.SalesYTD).NotNull();
		}

		private bool BeUniqueGetName(ApiSalesTerritoryModel model)
		{
			return this.SalesTerritoryRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>c5e8d7c87c9943954db5916319719b1e</Hash>
</Codenesium>*/