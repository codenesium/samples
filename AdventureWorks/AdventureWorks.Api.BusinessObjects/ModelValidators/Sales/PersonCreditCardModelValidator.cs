using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PersonCreditCardModelValidator: AbstractPersonCreditCardModelValidator, IPersonCreditCardModelValidator
	{
		public PersonCreditCardModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PersonCreditCardModel model)
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PersonCreditCardModel model)
		{
			this.CreditCardIDRules();
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
    <Hash>2fc20b3ca0ca6db25cb6dcd93a7e9d36</Hash>
</Codenesium>*/