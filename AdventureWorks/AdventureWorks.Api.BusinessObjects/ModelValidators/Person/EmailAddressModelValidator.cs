using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmailAddressRequestModelValidator: AbstractApiEmailAddressRequestModelValidator, IApiEmailAddressRequestModelValidator
	{
		public ApiEmailAddressRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model)
		{
			this.EmailAddress1Rules();
			this.EmailAddressIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model)
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
    <Hash>4a2f3b592d1ef4656a8d1111e21cef79</Hash>
</Codenesium>*/