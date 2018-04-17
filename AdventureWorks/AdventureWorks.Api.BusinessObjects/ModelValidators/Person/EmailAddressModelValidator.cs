using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class EmailAddressModelValidator: AbstractEmailAddressModelValidator, IEmailAddressModelValidator
	{
		public EmailAddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(EmailAddressModel model)
		{
			this.EmailAddressIDRules();
			this.EmailAddress1Rules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmailAddressModel model)
		{
			this.EmailAddressIDRules();
			this.EmailAddress1Rules();
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
    <Hash>d2d2731fb79077af252ed51d007cf20f</Hash>
</Codenesium>*/