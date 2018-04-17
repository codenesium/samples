using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesTerritoryHistoryModelValidator: AbstractSalesTerritoryHistoryModelValidator, ISalesTerritoryHistoryModelValidator
	{
		public SalesTerritoryHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesTerritoryHistoryModel model)
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesTerritoryHistoryModel model)
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
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
    <Hash>eee60d7bf8b96f68adf53914aa962028</Hash>
</Codenesium>*/