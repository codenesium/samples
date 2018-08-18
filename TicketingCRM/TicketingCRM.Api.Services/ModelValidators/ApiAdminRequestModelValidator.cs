using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiAdminRequestModelValidator : AbstractApiAdminRequestModelValidator, IApiAdminRequestModelValidator
	{
		public ApiAdminRequestModelValidator(IAdminRepository adminRepository)
			: base(adminRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			this.PhoneRules();
			this.UsernameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model)
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
    <Hash>828f625097f9fe7b13ab46608f695ed6</Hash>
</Codenesium>*/