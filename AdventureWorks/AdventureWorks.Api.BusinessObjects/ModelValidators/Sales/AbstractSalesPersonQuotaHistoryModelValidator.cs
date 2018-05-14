using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesPersonQuotaHistoryModelValidator: AbstractValidator<ApiSalesPersonQuotaHistoryModel>
	{
		public new ValidationResult Validate(ApiSalesPersonQuotaHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonQuotaHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void QuotaDateRules()
		{
			this.RuleFor(x => x.QuotaDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesQuotaRules()
		{
			this.RuleFor(x => x.SalesQuota).NotNull();
		}

		private bool BeValidSalesPerson(int id)
		{
			return this.SalesPersonRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>bc6420887e42d16dcffb35bc3935cb7f</Hash>
</Codenesium>*/