using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesPersonQuotaHistoryModelValidator: AbstractSalesPersonQuotaHistoryModelValidator, ISalesPersonQuotaHistoryModelValidator
	{
		public SalesPersonQuotaHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesPersonQuotaHistoryModel model)
		{
			this.QuotaDateRules();
			this.SalesQuotaRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesPersonQuotaHistoryModel model)
		{
			this.QuotaDateRules();
			this.SalesQuotaRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>cf9ac5ecebeb80a037f65b9af007c78b</Hash>
</Codenesium>*/