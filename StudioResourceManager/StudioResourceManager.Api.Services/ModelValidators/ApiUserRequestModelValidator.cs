using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiUserRequestModelValidator : AbstractApiUserRequestModelValidator, IApiUserRequestModelValidator
	{
		public ApiUserRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model)
		{
			this.PasswordRules();
			this.UsernameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserRequestModel model)
		{
			this.PasswordRules();
			this.UsernameRules();
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
    <Hash>69aa0dcdaff4909ffb6d38f7acd19ffc</Hash>
</Codenesium>*/