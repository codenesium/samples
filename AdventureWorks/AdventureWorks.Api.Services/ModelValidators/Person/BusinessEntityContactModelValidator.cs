using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBusinessEntityContactRequestModelValidator: AbstractApiBusinessEntityContactRequestModelValidator, IApiBusinessEntityContactRequestModelValidator
	{
		public ApiBusinessEntityContactRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model)
		{
			this.ContactTypeIDRules();
			this.ModifiedDateRules();
			this.PersonIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b7bac42ac9ed6118b39d41daa06695fb</Hash>
</Codenesium>*/