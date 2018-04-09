using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesPersonModelValidator: AbstractValidator<SalesPersonModel>
	{
		public new ValidationResult Validate(SalesPersonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesPersonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository {get; set;}
		public ISalesTerritoryRepository SalesTerritoryRepository {get; set;}
		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).Must(BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void SalesQuotaRules()
		{                       }

		public virtual void BonusRules()
		{
			RuleFor(x => x.Bonus).NotNull();
		}

		public virtual void CommissionPctRules()
		{
			RuleFor(x => x.CommissionPct).NotNull();
		}

		public virtual void SalesYTDRules()
		{
			RuleFor(x => x.SalesYTD).NotNull();
		}

		public virtual void SalesLastYearRules()
		{
			RuleFor(x => x.SalesLastYear).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidEmployee(int id)
		{
			return this.EmployeeRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesTerritory(Nullable<int> id)
		{
			return this.SalesTerritoryRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>1e67041cebf6de5de02495dbb5d6a35d</Hash>
</Codenesium>*/