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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesPersonModel model)
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

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>11f71f5813dc72dbdb6f7126125052bc</Hash>
</Codenesium>*/