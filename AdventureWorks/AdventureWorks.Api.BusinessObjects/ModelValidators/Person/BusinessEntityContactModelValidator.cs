using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBusinessEntityContactModelValidator: AbstractApiBusinessEntityContactModelValidator, IApiBusinessEntityContactModelValidator
	{
		public ApiBusinessEntityContactModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
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
    <Hash>5c78603df102d2405d8ac42bcdff782c</Hash>
</Codenesium>*/