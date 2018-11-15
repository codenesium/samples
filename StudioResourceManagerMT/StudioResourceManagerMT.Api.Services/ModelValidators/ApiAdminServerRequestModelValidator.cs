using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiAdminServerRequestModelValidator : AbstractApiAdminServerRequestModelValidator, IApiAdminServerRequestModelValidator
	{
		public ApiAdminServerRequestModelValidator(IAdminRepository adminRepository)
			: base(adminRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAdminServerRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminServerRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>222cd0716e09f6e9e5116f77e0eb32be</Hash>
</Codenesium>*/