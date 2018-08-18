using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPhoneNumberTypeRequestModelValidator : AbstractApiPhoneNumberTypeRequestModelValidator, IApiPhoneNumberTypeRequestModelValidator
	{
		public ApiPhoneNumberTypeRequestModelValidator(IPhoneNumberTypeRepository phoneNumberTypeRepository)
			: base(phoneNumberTypeRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f6c5cf08907cb92feb2d866d9d4df9cf</Hash>
</Codenesium>*/