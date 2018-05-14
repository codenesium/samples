using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesTerritoryHistoryModelValidator: AbstractValidator<ApiSalesTerritoryHistoryModel>
	{
		public new ValidationResult Validate(ApiSalesTerritoryHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).NotNull();
			this.RuleFor(x => x.TerritoryID).Must(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		private bool BeValidSalesPerson(int id)
		{
			return this.SalesPersonRepository.Get(id) != null;
		}

		private bool BeValidSalesTerritory(int id)
		{
			return this.SalesTerritoryRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>608f293660f6aaddfc39e719ca0dbc8a</Hash>
</Codenesium>*/