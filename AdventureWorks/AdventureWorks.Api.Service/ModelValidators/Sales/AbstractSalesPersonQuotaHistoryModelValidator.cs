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

		public ISalesPersonRepository SalesPersonRepository {get; set;}
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

		private bool BeValidSalesPerson(int id)
		{
			return this.SalesPersonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>5f56addf2f82fbb63990ebc1855995b6</Hash>
</Codenesium>*/