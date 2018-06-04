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
	public abstract class AbstractApiSalesPersonRequestModelValidator: AbstractValidator<ApiSalesPersonRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiSalesPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
		public virtual void BonusRules()
		{
			this.RuleFor(x => x.Bonus).NotNull();
		}

		public virtual void CommissionPctRules()
		{
			this.RuleFor(x => x.CommissionPct).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesLastYearRules()
		{
			this.RuleFor(x => x.SalesLastYear).NotNull();
		}

		public virtual void SalesQuotaRules()
		{                       }

		public virtual void SalesYTDRules()
		{
			this.RuleFor(x => x.SalesYTD).NotNull();
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesTerritory(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesTerritoryRepository.Get(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1bf600cccacddd30fdfa03409e8e1f4d</Hash>
</Codenesium>*/