using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiAdminRequestModelValidator : AbstractApiAdminRequestModelValidator, IApiAdminRequestModelValidator
	{
		public ApiAdminRequestModelValidator(IAdminRepository adminRepository)
			: base(adminRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.UserIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.UserIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f74324bd5a6117f24e05cf5f189bd0c8</Hash>
</Codenesium>*/