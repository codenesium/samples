using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonPhoneRequestModelValidator : AbstractApiPersonPhoneRequestModelValidator, IApiPersonPhoneRequestModelValidator
	{
		public ApiPersonPhoneRequestModelValidator(IPersonPhoneRepository personPhoneRepository)
			: base(personPhoneRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>21ad6fbdfa5dde3e7ab656ca4ca10dfd</Hash>
</Codenesium>*/