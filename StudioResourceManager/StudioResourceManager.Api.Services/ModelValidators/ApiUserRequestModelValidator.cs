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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserRequestModel model)
		{
			this.PasswordRules();
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
    <Hash>bf52d18b05bcd8f7744b93be8ba05469</Hash>
</Codenesium>*/