using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesPersonQuotaHistoryModelValidator: AbstractValidator<SalesPersonQuotaHistoryModel>
	{
		public new ValidationResult Validate(SalesPersonQuotaHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesPersonQuotaHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void QuotaDateRules()
		{
			RuleFor(x => x.QuotaDate).NotNull();
		}

		public virtual void SalesQuotaRules()
		{
			RuleFor(x => x.SalesQuota).NotNull();
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
    <Hash>108edb8e6167e7cbb9d8880d5783e3e3</Hash>
</Codenesium>*/