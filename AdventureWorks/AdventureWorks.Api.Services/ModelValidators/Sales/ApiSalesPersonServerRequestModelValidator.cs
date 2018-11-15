using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesPersonServerRequestModelValidator : AbstractApiSalesPersonServerRequestModelValidator, IApiSalesPersonServerRequestModelValidator
	{
		public ApiSalesPersonServerRequestModelValidator(ISalesPersonRepository salesPersonRepository)
			: base(salesPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonServerRequestModel model)
		{
			this.BonusRules();
			this.CommissionPctRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesQuotaRules();
			this.SalesYTDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonServerRequestModel model)
		{
			this.BonusRules();
			this.CommissionPctRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesQuotaRules();
			this.SalesYTDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>65346b30936fa4e2f1bd7d86be3ac265</Hash>
</Codenesium>*/