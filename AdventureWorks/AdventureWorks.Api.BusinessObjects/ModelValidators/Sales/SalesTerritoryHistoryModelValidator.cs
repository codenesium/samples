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
			this.EndDateRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesTerritoryHistoryModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
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
    <Hash>683faacac87c050258e0a56d2bf62ad1</Hash>
</Codenesium>*/