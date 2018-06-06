using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiSalesTerritoryHistoryRequestModelValidator: AbstractValidator<ApiSalesTerritoryHistoryRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiSalesTerritoryHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
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
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesPersonRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesTerritory(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesTerritoryRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>dc449aff533c8735d4fd7808bdef73f0</Hash>
</Codenesium>*/