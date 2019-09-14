using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractValidator<ApiUserServerRequestModel>, IApiUserServerRequestModelValidator
	{
		private int existingRecordId;

		protected IUserRepository UserRepository { get; private set; }

		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
		{
			this.UserRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model)
		{
			this.PasswordRules();
			this.UsernameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.PasswordRules();
			this.UsernameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Password).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x.Username).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Username).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>b4160e8b237053fe794a0d2fd96a197f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/