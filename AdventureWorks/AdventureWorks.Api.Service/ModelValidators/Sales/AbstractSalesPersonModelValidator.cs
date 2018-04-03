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

		public virtual void TerritoryIDRules()
		{                       }

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
	}
}

/*<Codenesium>
    <Hash>0f5ea2e970334346fc5b3c0f42b83452</Hash>
</Codenesium>*/