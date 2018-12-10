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
	public abstract class AbstractApiUserServerRequestModelValidator : AbstractValidator<ApiUserServerRequestModel>
	{
		private int existingRecordId;

		protected IUserRepository UserRepository { get; private set; }

		public AbstractApiUserServerRequestModelValidator(IUserRepository userRepository)
		{
			this.UserRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>9fa5f36c872e6abf75abb65610449b55</Hash>
</Codenesium>*/