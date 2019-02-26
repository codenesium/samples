using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractApiUserServerRequestModelValidator, IApiUserServerRequestModelValidator
	{
		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model)
		{
			this.EmailRules();
			this.PasswordRules();
			this.SubscriptionIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.EmailRules();
			this.PasswordRules();
			this.SubscriptionIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cf1ca847bd0926b3274641322b3fc95a</Hash>
</Codenesium>*/