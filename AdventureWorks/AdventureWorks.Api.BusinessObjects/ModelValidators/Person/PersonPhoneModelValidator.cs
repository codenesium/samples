using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PersonPhoneModelValidator: AbstractPersonPhoneModelValidator, IPersonPhoneModelValidator
	{
		public PersonPhoneModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PersonPhoneModel model)
		{
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PersonPhoneModel model)
		{
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
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
    <Hash>be95aba1188340aca698632d234d5593</Hash>
</Codenesium>*/