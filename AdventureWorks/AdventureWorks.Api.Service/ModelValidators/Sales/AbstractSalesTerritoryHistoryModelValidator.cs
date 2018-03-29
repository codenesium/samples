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

		public bool BeValidSalesPerson(int id)
		{
			Response response = new Response();

			this.SalesPersonRepository.GetById(id,response);
			return response.SalesPersons.Count > 0;
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
    <Hash>a3385df3c344bc82aeaee2bff01b082b</Hash>
</Codenesium>*/