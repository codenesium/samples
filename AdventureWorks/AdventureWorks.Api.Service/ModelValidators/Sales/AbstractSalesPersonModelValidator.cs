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

		public bool BeValidEmployee(int id)
		{
			Response response = new Response();

			this.EmployeeRepository.GetById(id,response);
			return response.Employees.Count > 0;
		}

		public bool BeValidSalesTerritory(Nullable<int> id)
		{
			Response response = new Response();

			this.SalesTerritoryRepository.GetById(id.GetValueOrDefault(),response);
			return response.SalesTerritories.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>4079bda67f703d0e141bca86087324f5</Hash>
</Codenesium>*/