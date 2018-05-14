using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPersonPhoneModelValidator: AbstractApiPersonPhoneModelValidator, IApiPersonPhoneModelValidator
	{
		public ApiPersonPhoneModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneModel model)
		{
			this.ModifiedDateRules();
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneModel model)
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
    <Hash>708cf8c61891396798c05f712dfff914</Hash>
</Codenesium>*/