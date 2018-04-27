using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			return this.SalesPersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>3376776fd5cda5703a0f93b780f156e2</Hash>
</Codenesium>*/