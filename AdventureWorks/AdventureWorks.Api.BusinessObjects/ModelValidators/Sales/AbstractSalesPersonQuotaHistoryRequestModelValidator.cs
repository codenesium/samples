using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesPersonQuotaHistoryRequestModelValidator: AbstractValidator<ApiSalesPersonQuotaHistoryRequestModel>
	{
		public new ValidationResult Validate(ApiSalesPersonQuotaHistoryRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonQuotaHistoryRequestModel model)
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

		private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesPersonRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4b5d5077db849e564ad1b172e8890e7a</Hash>
</Codenesium>*/