using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiFollowerRequestModelValidator : AbstractApiFollowerRequestModelValidator, IApiFollowerRequestModelValidator
	{
		public ApiFollowerRequestModelValidator(IFollowerRepository followerRepository)
			: base(followerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFollowerRequestModel model)
		{
			this.BlockedRules();
			this.DateFollowedRules();
			this.FollowRequestStatuRules();
			this.FollowedUserIdRules();
			this.FollowingUserIdRules();
			this.MutedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowerRequestModel model)
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
	}
}

/*<Codenesium>
    <Hash>2dcf8d255105a9e539fba65347060aa2</Hash>
</Codenesium>*/