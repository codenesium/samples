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
			this.EmailAddress1Rules();
			this.EmailAddressIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmailAddressModel model)
		{
			this.EmailAddress1Rules();
			this.EmailAddressIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4e46ee1d0c685f20abfb638584880171</Hash>
</Codenesium>*/