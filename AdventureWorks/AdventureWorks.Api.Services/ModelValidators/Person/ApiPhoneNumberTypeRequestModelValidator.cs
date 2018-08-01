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
    <Hash>2eae6f87dea6fcef3cc0bad45e98f308</Hash>
</Codenesium>*/