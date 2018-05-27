using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPersonPhoneRequestModelValidator: AbstractApiPersonPhoneRequestModelValidator, IApiPersonPhoneRequestModelValidator
	{
		public ApiPersonPhoneRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model)
		{
			this.ModifiedDateRules();
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model)
		{
			this.ModifiedDateRules();
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c56bf5135d9b33285bd302e04c2af719</Hash>
</Codenesium>*/