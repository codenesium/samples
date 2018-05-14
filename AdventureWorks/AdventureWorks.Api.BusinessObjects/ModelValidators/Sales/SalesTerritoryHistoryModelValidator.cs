using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesTerritoryHistoryModelValidator: AbstractApiSalesTerritoryHistoryModelValidator, IApiSalesTerritoryHistoryModelValidator
	{
		public ApiSalesTerritoryHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryModel model)
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
    <Hash>2b162e5b184b2d96a8e696f90ae03f33</Hash>
</Codenesium>*/