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

		public virtual void SubscriptionIdRules()
		{
			this.RuleFor(x => x.SubscriptionId).MustAsync(this.BeValidSubscriptionBySubscriptionId).When(x => !x?.SubscriptionId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSubscriptionBySubscriptionId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.UserRepository.SubscriptionBySubscriptionId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>fae7e0a89628fc6930e4ee0f33b80257</Hash>
</Codenesium>*/