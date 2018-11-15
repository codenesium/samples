using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesPersonServerRequestModelValidator : AbstractValidator<ApiSalesPersonServerRequestModel>
	{
		private int existingRecordId;

		private ISalesPersonRepository salesPersonRepository;

		public AbstractApiSalesPersonServerRequestModelValidator(ISalesPersonRepository salesPersonRepository)
		{
			this.salesPersonRepository = salesPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BonusRules()
		{
		}

		public virtual void CommissionPctRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesPersonServerRequestModel.Rowguid));
		}

		public virtual void SalesLastYearRules()
		{
		}

		public virtual void SalesQuotaRules()
		{
		}

		public virtual void SalesYTDRules()
		{
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => !x?.TerritoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesTerritoryByTerritoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.salesPersonRepository.SalesTerritoryByTerritoryID(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeUniqueByRowguid(ApiSalesPersonServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesPerson record = await this.salesPersonRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a49feaedfdd8894a888a136e67a42685</Hash>
</Codenesium>*/