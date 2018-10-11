using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesTerritoryHistoryRequestModelValidator : AbstractValidator<ApiSalesTerritoryHistoryRequestModel>
	{
		private int existingRecordId;

		private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

		public AbstractApiSalesTerritoryHistoryRequestModelValidator(ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository)
		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => x?.TerritoryID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesPersonByBusinessEntityID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesTerritoryHistoryRepository.SalesPersonByBusinessEntityID(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesTerritoryByTerritoryID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesTerritoryHistoryRepository.SalesTerritoryByTerritoryID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>ce0a713303aab35ad17fba419d37356e</Hash>
</Codenesium>*/