using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
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
			this.EmailRules();
			this.PasswordRules();
			this.StripeCustomerIdRules();
			this.SubscriptionTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.EmailRules();
			this.PasswordRules();
			this.StripeCustomerIdRules();
			this.SubscriptionTypeIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Password).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StripeCustomerIdRules()
		{
			this.RuleFor(x => x.StripeCustomerId).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.StripeCustomerId).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SubscriptionTypeIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8a17c384f1890fdc45cd88926316e803</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/