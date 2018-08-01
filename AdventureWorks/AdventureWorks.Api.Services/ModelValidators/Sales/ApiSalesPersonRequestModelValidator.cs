using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesPersonRequestModelValidator : AbstractApiSalesPersonRequestModelValidator, IApiSalesPersonRequestModelValidator
	{
		public ApiSalesPersonRequestModelValidator(ISalesPersonRepository salesPersonRepository)
			: base(salesPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model)
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
    <Hash>a618783b5842fe0cb0e27b413f307827</Hash>
</Codenesium>*/