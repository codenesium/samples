using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCustomerRequestModelValidator: AbstractApiCustomerRequestModelValidator, IApiCustomerRequestModelValidator
	{
		public ApiCustomerRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model)
		{
			this.AccountNumberRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model)
		{
			this.AccountNumberRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			this.StoreIDRules();
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
    <Hash>2e2b20f78a15af759168f37911aab68e</Hash>
</Codenesium>*/