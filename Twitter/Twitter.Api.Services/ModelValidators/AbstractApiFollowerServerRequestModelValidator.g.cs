using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiFollowerServerRequestModelValidator : AbstractValidator<ApiFollowerServerRequestModel>
	{
		private int existingRecordId;

		private IFollowerRepository followerRepository;

		public AbstractApiFollowerServerRequestModelValidator(IFollowerRepository followerRepository)
		{
			this.followerRepository = followerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BlockedRules()
		{
			this.RuleFor(x => x.Blocked).NotNull();
			this.RuleFor(x => x.Blocked).Length(0, 1);
		}

		public virtual void DateFollowedRules()
		{
		}

		public virtual void FollowRequestStatuRules()
		{
			this.RuleFor(x => x.FollowRequestStatu).NotNull();
			this.RuleFor(x => x.FollowRequestStatu).Length(0, 1);
		}

		public virtual void FollowedUserIdRules()
		{
			this.RuleFor(x => x.FollowedUserId).MustAsync(this.BeValidUserByFollowedUserId).When(x => !x?.FollowedUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void FollowingUserIdRules()
		{
			this.RuleFor(x => x.FollowingUserId).MustAsync(this.BeValidUserByFollowingUserId).When(x => !x?.FollowingUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void MutedRules()
		{
			this.RuleFor(x => x.Muted).NotNull();
			this.RuleFor(x => x.Muted).Length(0, 1);
		}

		private async Task<bool> BeValidUserByFollowedUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.followerRepository.UserByFollowedUserId(id);

			return record != null;
		}

		private async Task<bool> BeValidUserByFollowingUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.followerRepository.UserByFollowingUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0e1494e25b5fec1630af11de22a1204a</Hash>
</Codenesium>*/