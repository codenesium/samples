using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPhoneNumberTypeModelValidator: AbstractApiPhoneNumberTypeModelValidator, IApiPhoneNumberTypeModelValidator
	{
		public ApiPhoneNumberTypeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1c9fd0865c57daa948d71579965fd1ef</Hash>
</Codenesium>*/