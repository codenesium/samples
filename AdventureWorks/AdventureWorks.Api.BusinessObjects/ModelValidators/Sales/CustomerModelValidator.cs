using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CustomerModelValidator: AbstractCustomerModelValidator, ICustomerModelValidator
	{
		public CustomerModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CustomerModel model)
		{
			this.PersonIDRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			this.AccountNumberRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, CustomerModel model)
		{
			this.PersonIDRules();
			this.StoreIDRules();
			this.TerritoryIDRules();
			this.AccountNumberRules();
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
    <Hash>2f83db8f92c9c8dcf9404c9573943618</Hash>
</Codenesium>*/