using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowerServerRequestModelValidator : AbstractValidator<ApiFollowerServerRequestModel>, IApiFollowerServerRequestModelValidator
	{
		private int existingRecordId;

		protected IFollowerRepository FollowerRepository { get; private set; }

		public ApiFollowerServerRequestModelValidator(IFollowerRepository followerRepository)
		{
			this.FollowerRepository = followerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowerServerRequestModel model)
		{
			this.BlockedRules();
			this.DateFollowedRules();
			this.FollowRequestStatuRules();
			this.FollowedUserIdRules();
			this.FollowingUserIdRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowerServerRequestModel model)
		{
			this.BlockedRules();
			this.DateFollowedRules();
			this.FollowRequestStatuRules();
			this.FollowedUserIdRules();
			this.FollowingUserIdRules();
			this.MutedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void BlockedRules()
		{
			this.RuleFor(x => x.Blocked).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Blocked).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DateFollowedRules()
		{
		}

		public virtual void FollowRequestStatuRules()
		{
			this.RuleFor(x => x.FollowRequestStatu).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FollowRequestStatu).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FollowedUserIdRules()
		{
			this.RuleFor(x => x.FollowedUserId).MustAsync(this.BeValidUserByFollowedUserId).When(x => !x?.FollowedUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void FollowingUserIdRules()
		{
			this.RuleFor(x => x.FollowingUserId).MustAsync(this.BeValidUserByFollowingUserId).When(x => !x?.FollowingUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void MutedRules()
		{
			this.RuleFor(x => x.Muted).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Muted).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidUserByFollowedUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.FollowerRepository.UserByFollowedUserId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByFollowingUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.FollowerRepository.UserByFollowingUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1388e2b74f0e7c8086d10b7c77e04d18</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/