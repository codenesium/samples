using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesPersonQuotaHistoryModelValidator: AbstractApiSalesPersonQuotaHistoryModelValidator, IApiSalesPersonQuotaHistoryModelValidator
	{
		public ApiSalesPersonQuotaHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryModel model)
		{
			this.ModifiedDateRules();
			this.QuotaDateRules();
			this.RowguidRules();
			this.SalesQuotaRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryModel model)
		{
			this.ModifiedDateRules();
			this.QuotaDateRules();
			this.RowguidRules();
			this.SalesQuotaRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>36e6ae197206b3edca9add0c0692fcad</Hash>
</Codenesium>*/