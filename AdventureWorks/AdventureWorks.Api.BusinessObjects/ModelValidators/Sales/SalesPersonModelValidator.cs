using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesPersonModelValidator: AbstractSalesPersonModelValidator, ISalesPersonModelValidator
	{
		public SalesPersonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesPersonModel model)
		{
			this.TerritoryIDRules();
			this.SalesQuotaRules();
			this.BonusRules();
			this.CommissionPctRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesPersonModel model)
		{
			this.TerritoryIDRules();
			this.SalesQuotaRules();
			this.BonusRules();
			this.CommissionPctRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
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
    <Hash>f26cf410deee51628e55f6314c758ea0</Hash>
</Codenesium>*/