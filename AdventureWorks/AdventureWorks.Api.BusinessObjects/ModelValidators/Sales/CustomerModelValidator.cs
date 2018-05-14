using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiCustomerModelValidator: AbstractApiCustomerModelValidator, IApiCustomerModelValidator
	{
		public ApiCustomerModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerModel model)
		{
			this.AccountNumberRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerModel model)
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
    <Hash>aac9c7b794193729a612c255c9a9543d</Hash>
</Codenesium>*/