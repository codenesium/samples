using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPhoneNumberTypeServerRequestModelValidator : AbstractApiPhoneNumberTypeServerRequestModelValidator, IApiPhoneNumberTypeServerRequestModelValidator
	{
		public ApiPhoneNumberTypeServerRequestModelValidator(IPhoneNumberTypeRepository phoneNumberTypeRepository)
			: base(phoneNumberTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeServerRequestModel model)
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
    <Hash>62a30970edcf09d3f45d51e5ea176191</Hash>
</Codenesium>*/