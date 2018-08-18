using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesPersonQuotaHistoryRequestModelValidator : AbstractApiSalesPersonQuotaHistoryRequestModelValidator, IApiSalesPersonQuotaHistoryRequestModelValidator
	{
		public ApiSalesPersonQuotaHistoryRequestModelValidator(ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository)
			: base(salesPersonQuotaHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.QuotaDateRules();
			this.RowguidRules();
			this.SalesQuotaRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.QuotaDateRules();
			this.RowguidRules();
			this.SalesQuotaRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>447c0ac13721c4c26558b181946b391c</Hash>
</Codenesium>*/