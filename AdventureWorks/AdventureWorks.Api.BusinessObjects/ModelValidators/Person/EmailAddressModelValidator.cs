using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmailAddressModelValidator: AbstractApiEmailAddressModelValidator, IApiEmailAddressModelValidator
	{
		public ApiEmailAddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressModel model)
		{
			this.EmailAddress1Rules();
			this.EmailAddressIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressModel model)
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
    <Hash>7c9d236a60605bbcbeaeaa1d1f5e2788</Hash>
</Codenesium>*/