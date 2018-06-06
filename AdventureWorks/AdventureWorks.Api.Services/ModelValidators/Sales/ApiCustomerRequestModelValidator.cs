using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>47789057935f6c04b3b0d39b0d8b3cfc</Hash>
</Codenesium>*/