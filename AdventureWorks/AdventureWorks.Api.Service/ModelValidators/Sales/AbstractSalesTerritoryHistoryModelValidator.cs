using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesTerritoryHistoryModelValidator: AbstractValidator<SalesTerritoryHistoryModel>
	{
		public new ValidationResult Validate(SalesTerritoryHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesTerritoryHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesPersonRepository SalesPersonRepository {get; set;}
		public ISalesTerritoryRepository SalesTerritoryRepository {get; set;}
		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).NotNull();
			RuleFor(x => x.TerritoryID).Must(BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidSalesPerson(int id)
		{
			return this.SalesPersonRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesTerritory(int id)
		{
			return this.SalesTerritoryRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ac53e8c80dedb1d110fbaeaf7afbe47c</Hash>
</Codenesium>*/