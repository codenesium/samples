using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiAdminServerRequestModelValidator : AbstractApiAdminServerRequestModelValidator, IApiAdminServerRequestModelValidator
	{
		public ApiAdminServerRequestModelValidator(IAdminRepository adminRepository)
			: base(adminRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAdminServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			this.PhoneRules();
			this.UsernameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			this.PhoneRules();
			this.UsernameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>bb93e94b396395dccca2e32715af41b8</Hash>
</Codenesium>*/