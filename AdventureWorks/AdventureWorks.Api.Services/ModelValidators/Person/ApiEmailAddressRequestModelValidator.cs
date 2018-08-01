using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiEmailAddressRequestModelValidator : AbstractApiEmailAddressRequestModelValidator, IApiEmailAddressRequestModelValidator
	{
		public ApiEmailAddressRequestModelValidator(IEmailAddressRepository emailAddressRepository)
			: base(emailAddressRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>908770891ce9a3c9c3d5f1c219e5e70c</Hash>
</Codenesium>*/