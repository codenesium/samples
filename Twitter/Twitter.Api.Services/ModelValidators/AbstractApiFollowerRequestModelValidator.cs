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
	public abstract class AbstractApiFollowerRequestModelValidator : AbstractValidator<ApiFollowerRequestModel>
	{
		private int existingRecordId;

		private IFollowerRepository followerRepository;

		public AbstractApiFollowerRequestModelValidator(IFollowerRepository followerRepository)
		{
			this.followerRepository = followerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowerRequestModel model, int id)
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
			this.RuleFor(x => x.FollowedUserId).MustAsync(this.BeValidUserByFollowedUserId).When(x => x?.FollowedUserId != null).WithMessage("Invalid reference");
		}

		public virtual void FollowingUserIdRules()
		{
			this.RuleFor(x => x.FollowingUserId).MustAsync(this.BeValidUserByFollowingUserId).When(x => x?.FollowingUserId != null).WithMessage("Invalid reference");
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
    <Hash>4a43f58f1c1014de2df6dc9be3238cee</Hash>
</Codenesium>*/