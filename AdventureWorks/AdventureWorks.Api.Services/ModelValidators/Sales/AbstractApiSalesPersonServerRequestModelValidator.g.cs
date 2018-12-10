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
	public abstract class AbstractApiSalesPersonServerRequestModelValidator : AbstractValidator<ApiSalesPersonServerRequestModel>
	{
		private int existingRecordId;

		protected ISalesPersonRepository SalesPersonRepository { get; private set; }

		public AbstractApiSalesPersonServerRequestModelValidator(ISalesPersonRepository salesPersonRepository)
		{
			this.SalesPersonRepository = salesPersonRepository;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesPersonServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
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
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => !x?.TerritoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSalesTerritoryByTerritoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesPersonRepository.SalesTerritoryByTerritoryID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeUniqueByRowguid(ApiSalesPersonServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesPerson record = await this.SalesPersonRepository.ByRowguid(model.Rowguid);

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
    <Hash>996b2e89251f749ff05e2465c7ae866e</Hash>
</Codenesium>*/