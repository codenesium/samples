using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPhoneNumberTypeRequestModelValidator: AbstractApiPhoneNumberTypeRequestModelValidator, IApiPhoneNumberTypeRequestModelValidator
	{
		public ApiPhoneNumberTypeRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1f82a7ea212b1972b5acb7370166af5f</Hash>
</Codenesium>*/